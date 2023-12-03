using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager.DriverConfigs.Impl;

namespace sample.Utilities
{
    class BaseMethods
    {
        public static IWebDriver driver;
        static Actions a;
        public static void LaunchBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();

        }
        public static void Maximize()
        {
            driver.Manage().Window.Maximize();
        }
        public static void Openurl(String url)
        {
            driver.Url = url;
        }
        public static void ImplicitWait()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
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
            a = new Actions(driver);
            a.MoveToElement(e).Perform();
        }
        public static void TakeSnap(String path)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            ts.GetScreenshot().SaveAsFile(path, ScreenshotImageFormat.Jpeg);

        }
        public static void MoveToWindow(int index)
        {
            driver.SwitchTo().Window(driver.WindowHandles[index]);
        }

    }
}
