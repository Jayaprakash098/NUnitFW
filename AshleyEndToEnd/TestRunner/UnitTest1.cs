using AshleyEndToEnd.PageObjects;
using AshleyEndToEnd.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace AshleyEndToEnd
{
    [Parallelizable(ParallelScope.Self)]
    class UnitTest1 : BaseTest
    {
       

        [Test,TestCaseSource("CreditCardDataConfig1"),Category("smoke")]
        [Parallelizable(ParallelScope.All)]
        public void VisaAndMasterCardFlow(String ccfirstname, String cardno, String month, String year, String cvv)
        {
            /*IWebDriver driver = new ChromeDriver(@"C:\Users\JP\Downloads\chromedriver_win32");
          driver.Navigate().GoToUrl("https://storefront:afweb2017@staging.ashleyfurniture.com/");
          driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
          driver.Manage().Window.Maximize();*/

            AshleyPage page = new AshleyPage(driver.Value);
            page.getDetails().Click();
            page.getProceed().Click();

            Thread.Sleep(5000);

            IWebElement f = driver.Value.FindElement(By.XPath("//iframe[@id='fcopt-offer-133688-content']"));
            driver.Value.SwitchTo().Frame(f);
            driver.Value.FindElement(By.XPath("//span[text()='X']")).Click();

            page.getSelectUS().Click();
            page.getSetZipcode().SendKeys("33606");
           // page.getSubmitZipcode().Click();

            driver.Value.Navigate().Refresh();

            IWebElement furniture = driver.Value.FindElement(By.XPath("(//span[text()='Furniture'])[1]"));
            Mouseover(furniture);

            page.getClickSofas().Click();

            page.getSelectItem().Click();
            page.getAddToCart().Click();
            Thread.Sleep(3000);

            page.getCartIcon().Click();

            page.getSecureCheckout().Click();

            page.DeliveryDetails("FirstName","LastName","100 Main Street","Tampa","Florida","8132506272", "autotester803@gmail.com");

            driver.Value.FindElement(By.XPath("//span[text()='Use Original']")).Click();
            driver.Value.FindElement(By.XPath("//span[text()='Continue to Billing & Payment']")).Click();

            page.CreditCardDetails(ccfirstname,cardno,month,year,cvv);
            //page.getOrderContinue().Click();

           /* page.getPlaceOrder().Click();

            String orderNO = driver.Value.FindElement(By.XPath("//span[@class='sales-order-number-label']")).Text;
            Console.WriteLine(orderNO);
         */
        }
        public static IEnumerable<TestCaseData> CreditCardDataConfig1()
        {
            yield return new TestCaseData("FirstName", "4000000000000002", "December", "2022", "382");
            yield return new TestCaseData("FirstName", "5121212121212124", "December", "2022", "382");

        }

        [Test, TestCaseSource("CreditCardDataConfig2"), Category("regression")]
        [Parallelizable(ParallelScope.All)]
        public void DiscoverAndAmexFlow(String ccfirstname, String cardno, String month, String year, String cvv)
        {
           
            AshleyPage page = new AshleyPage(driver.Value);
            page.getDetails().Click();
            page.getProceed().Click();

            Thread.Sleep(5000);

            IWebElement f = driver.Value.FindElement(By.XPath("//iframe[@id='fcopt-offer-133688-content']"));
            driver.Value.SwitchTo().Frame(f);
            driver.Value.FindElement(By.XPath("//span[text()='X']")).Click();

            page.getSelectUS().Click();
            page.getSetZipcode().SendKeys("33606");
            page.getSubmitZipcode().Click();

            driver.Value.Navigate().Refresh();

            IWebElement furniture = driver.Value.FindElement(By.XPath("(//span[text()='Furniture'])[1]"));
            Mouseover(furniture);

            page.getClickSofas().Click();

            page.getSelectItem().Click();
            page.getAddToCart().Click();
            Thread.Sleep(3000);

            page.getCartIcon().Click();

            page.getSecureCheckout().Click();

            page.DeliveryDetails("FirstName", "LastName", "100 Main Street", "Tampa", "Florida", "8132506272", "autotester803@gmail.com");

            driver.Value.FindElement(By.XPath("//span[text()='Use Original']")).Click();
            driver.Value.FindElement(By.XPath("//span[text()='Continue to Billing & Payment']")).Click();

            page.CreditCardDetails(ccfirstname, cardno, month, year, cvv);
           // page.getOrderContinue().Click();

            //page.getPlaceOrder().Click();

           /* String orderNO = driver.Value.FindElement(By.XPath("//span[@class='sales-order-number-label']")).Text;
            Console.WriteLine(orderNO);*/
        }
        public static IEnumerable<TestCaseData> CreditCardDataConfig2()
        {
           
            yield return new TestCaseData("FirstName", "6011000000000004", "December", "2022", "382");
            yield return new TestCaseData("FirstName", "370000000000002", "December", "2022", "382");


        }
    }
}