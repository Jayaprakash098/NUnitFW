using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace Amazon.Utilities
{
    class BaseTest : BaseMethods
    {
       
        [SetUp]

        public void BrowserLaunch()
        {
            String browserName = ConfigurationManager.AppSettings["browser"];
            InitBrowser(browserName);
            LaunchBrowser(@"C:\Users\JP\Downloads\chromedriver_win32");
            Maximize();
            Openurl("https://www.amazon.in/");
            ImplicitWait();

        }

        public IWebDriver getDriver()
        {
            return driver;
        }

        public void InitBrowser(String browserName)
        {
            switch (browserName)
            {
                case "chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;

                case "firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

                case "edge":
                    driver = new EdgeDriver();
                    break;

            }
        }
        [TearDown]
        public void CloseBrowser()
        {
            TakeSnap(@"C:\Users\JP\source\repos\Practice\Amazon\Screenshots\s1.png");
            CloseBrowser();
        }


       

      /*  [OneTimeSetUp]
        public void Setup()
        {

            var workingDirectory = Environment.CurrentDirectory;
            String projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath = projectDirectory + "//index.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent.AttachReporter(htmlReporter);
        }
        [OneTimeTearDown]
        public void Teardown()
        {
            extent.Flush();
        }
*/
    }
}
