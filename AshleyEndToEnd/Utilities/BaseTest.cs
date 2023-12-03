using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Threading;
using WebDriverManager.DriverConfigs.Impl;

namespace AshleyEndToEnd.Utilities
{

    class BaseTest : BaseMethods
    {
        ExtentReports extent;
        ExtentTest test;
       
        [OneTimeSetUp]
        public void InitReport()
        {

            String workingDirectory = Environment.CurrentDirectory;
            String projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath = projectDirectory + "//index.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Environment","QA");
        }
        
        [SetUp]
        public void BeforeTest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            String browserName = ConfigurationManager.AppSettings["browser"];
            InitBrowser(browserName);
            /*driver.Value.Manage().Cookies.DeleteAllCookies();*/
            Maximize();
            ImplicitWait();
            Openurl("https://storefront:afweb2017@staging.ashleyfurniture.com/");

        }
        public IWebDriver getDriver()
        {
            return driver.Value;
        }

       public void InitBrowser(String browserName)
        {
            switch (browserName)
            {
                case "chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver.Value = new ChromeDriver();
                    break;

                case "firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver.Value = new FirefoxDriver();
                    break;

                case "edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver.Value = new EdgeDriver();
                    break;
            }
        }

        [TearDown]
        public void FinalizeReport()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;

            DateTime time = DateTime.Now;
            string fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";

            if(status == TestStatus.Failed)
            {
                test.Fail("Test Failed", CaptureScreenshot(driver.Value, fileName));
                test.Log(Status.Fail, "test failed with"+stackTrace);
            }
            else if (status == TestStatus.Passed)
            {
                test.Pass("Test Passed", CaptureScreenshot(driver.Value, fileName));
                test.Log(Status.Pass, "Credit card flow passed");
            }
            extent.Flush();
            driver.Value.Quit();

        }
        public static MediaEntityModelProvider CaptureScreenshot(IWebDriver driver, String ssname)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, ssname).Build();
        }
       
    }
}
