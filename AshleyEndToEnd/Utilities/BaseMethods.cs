using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using WebDriverManager.DriverConfigs.Impl;

namespace AshleyEndToEnd.Utilities
{
    class BaseMethods 
    {

        public static ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        static Actions a;
        public static void LaunchBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver.Value = new ChromeDriver();

        }
        public static void Maximize()
        {
            driver.Value.Manage().Window.Maximize();
        }
        public static void Openurl(String url)
        {
            driver.Value.Url = url;
        }
        public static void ImplicitWait()
        {
            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }
        public static void TextValues(IWebElement e, String text)
        {
            e.SendKeys(text);
        }
        public static void ClickBtn(IWebElement e)
        {
            e.Click();
        }
        public static void Mouseover(IWebElement e)
        {
            a = new Actions(driver.Value);
            a.MoveToElement(e).Perform();
        }
        public static void TakeSnap(String path)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            ts.GetScreenshot().SaveAsFile(path, ScreenshotImageFormat.Png);
            
        }
        public static void MoveToWindow(int index)
        {
            driver.Value.SwitchTo().Window(driver.Value.WindowHandles[index]);
        }
        public static void DropDownByText(IWebElement e,String text)
        {
            SelectElement s = new SelectElement(e);
            s.SelectByText(text);
        }


    }
}
