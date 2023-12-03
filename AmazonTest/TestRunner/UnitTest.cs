using Amazon.PageObjects;
using Amazon.Utilities;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System;
using System.IO;

namespace Amazon
{
    [TestFixture]
    class UnitTest : BaseTest
    {
        [Test]
       public void TestCase()
        
        {

                AmazonPage am = new AmazonPage(getDriver());

                am.getSearchTextBox().SendKeys("iphone13");
                am.getSearchButton().Click();

                am.getProductiPhone().Click();

                Console.WriteLine("Parent window = " + driver.CurrentWindowHandle);

                /*List<String> allWdw = driver.WindowHandles.ToList();
                foreach (String child in allWdw)
                {
                    if (!parWdw.Equals(child))
                    {
                        driver.SwitchTo().Window(child);
                    }
                }*/
                Console.WriteLine("All window ID " + driver.WindowHandles);
                MoveToWindow(1);
                am.getCartButton().Click();

                driver.Close();
                MoveToWindow(0);
                am.getAllMenu().Click();
                am.getSubMenu().Click();
                am.getCaseAndCovers().Click();
                am.getAppleCase().Click();
                am.getiPhone13Case().Click();
                am.getSelectedCase().Click();

                MoveToWindow(1);

                am.getCartButton().Click();
                am.getGoToCartButton().Click();
                am.getCheckoutButton().Click();

        }
    }
}

