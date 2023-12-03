using AshleyFurniture.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace AshleyFurniture
{
    class Program : Base
    {
        [Test]
       public void EndToEndFlow()
        {
            /*IWebDriver driver = new ChromeDriver(@"C:\Users\JP\Downloads\chromedriver_win32");
            driver.Navigate().GoToUrl("https://storefront:afweb2017@staging.ashleyfurniture.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.Manage().Window.Maximize();*/

            driver.FindElement(By.Id("details-button")).Click();
            driver.FindElement(By.Id("proceed-link")).Click();


            IWebElement f = driver.FindElement(By.XPath("//iframe[@id='fcopt-offer-133688-content']"));
            driver.SwitchTo().Frame(f);
            driver.FindElement(By.XPath("//span[text()='X']")).Click();

            driver.FindElement(By.XPath("(//button[text()='Ashley United States'])[2]")).Click();
            driver.FindElement(By.XPath("//input[@type='tel']")).SendKeys("33606");
            driver.FindElement(By.XPath("(//button[@type='submit'])[3]")).Click();

            driver.Navigate().Refresh();

            Actions a = new Actions(driver);
            IWebElement furniture = driver.FindElement(By.XPath("(//span[text()='Furniture'])[1]"));
            a.MoveToElement(furniture).Perform();

            IWebElement sofa = driver.FindElement(By.XPath("//a[text()='Sofas']"));
            sofa.Click();

            driver.FindElement(By.XPath("//img[@alt='Darcy Sofa, Cobblestone, large']")).Click();
            driver.FindElement(By.Id("add-to-cart")).Click();

            driver.FindElement(By.XPath("//a[@aria-label='View Shopping Cart']")).Click();

           /* AshleyPageObjects ashleyPage = new AshleyPageObjects(driver);
            ashleyPage.getCartBtn().Click();*/


            driver.FindElement(By.XPath("//button[@value='Secure Checkout']")).Click();

            driver.FindElement(By.XPath("(//input[@type='text'])[1]")).SendKeys("FirstName");
            driver.FindElement(By.XPath("(//input[@type='text'])[2]")).SendKeys("LastName");
            driver.FindElement(By.XPath("(//input[@type='text'])[3]")).SendKeys("100 Main Street");
            driver.FindElement(By.XPath("(//input[@type='text'])[5]")).SendKeys("Tampa");

            SelectElement s = new SelectElement(driver.FindElement(By.Id("dwfrm_singleshipping_shippingAddress_addressFields_states_state")));
            s.SelectByText("Florida");
            driver.FindElement(By.XPath("(//input[@type='tel'])[2]")).SendKeys("8132506272");
            driver.FindElement(By.XPath("(//input[@type='email'])[1]")).SendKeys("autotester803@gmail.com");

            driver.FindElement(By.XPath("//span[text()='Continue as Guest']")).Click();

            driver.FindElement(By.XPath("//span[text()='Use Original']")).Click();
            driver.FindElement(By.XPath("//span[text()='Continue to Billing & Payment']")).Click();

            driver.FindElement(By.Id("dwfrm_billing_paymentMethods_creditCard_owner")).SendKeys("FirstName");
            driver.FindElement(By.Id("dwfrm_billing_paymentMethods_creditCard_number")).SendKeys("4000000000000002");

            SelectElement s1 = new SelectElement(driver.FindElement(By.Id("dwfrm_billing_paymentMethods_creditCard_expiration_month")));
            s1.SelectByText("December");

            SelectElement s2 = new SelectElement(driver.FindElement(By.Id("dwfrm_billing_paymentMethods_creditCard_expiration_year")));
            s2.SelectByText("2022");

            driver.FindElement(By.Id("dwfrm_billing_paymentMethods_creditCard_cvn")).SendKeys("382");

            driver.FindElement(By.XPath("(//span[text()='Continue to Order Review'])[1]")).Click();

            driver.FindElement(By.XPath("//button[@value='Place Order']")).Click();

            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(@"C:\Users\JP\source\repos\Practice\AshleyFurniture\Screenshot\sample.png", ScreenshotImageFormat.Png);

            String title = driver.Title;
            Console.WriteLine(title);

        }
    }
}
