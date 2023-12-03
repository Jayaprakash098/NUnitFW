using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using WebDriverManager.DriverConfigs.Impl;

namespace demo
{
    public class Tests
    {
        public static IWebDriver driver;
        [Test]
        public void Test1()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.facebook.com";
            try
            {
                driver.FindElement(By.Id("el")).SendKeys("johnnysmith");
            }
            catch (NoSuchElementException)
            {
              
                driver.FindElement(By.Id("email")).SendKeys("johnnysmith");
            }
            finally
            {
                driver.FindElement(By.Id("pass")).SendKeys("15695255");
            }
            driver.Close();
        }
    }
}