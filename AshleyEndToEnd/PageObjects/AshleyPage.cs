using AshleyEndToEnd.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AshleyEndToEnd.PageObjects
{
    class AshleyPage : BaseMethods
    {
        private IWebDriver driver;
        public AshleyPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }

        [FindsBy(How = How.Id, Using = "details-button")]
        private IWebElement details;
        public IWebElement getDetails()
        {
            return details;
        }

        [FindsBy(How = How.Id, Using = "proceed-link")]
        private IWebElement proceed;
        public IWebElement getProceed()
        {
            return proceed;
        }


        [FindsBy(How = How.XPath, Using = "(//button[text()='Ashley United States'])[2]")]
        private IWebElement selectUS;

        public IWebElement getSelectUS()
        {
            return selectUS;
        }

        [FindsBy(How = How.XPath, Using = "//input[@type='tel']")]
        private IWebElement setZipcode;

        public IWebElement getSetZipcode()
        {
            return setZipcode;
        }
        [FindsBy(How = How.XPath, Using = "(//button[@type='submit'])[3]")]
        private IWebElement submitZipcode;

        public IWebElement getSubmitZipcode()
        {
            return submitZipcode;
        }
        [FindsBy(How = How.XPath, Using = "//a[text()='Sofas']")]
        private IWebElement clickSofas;

        public IWebElement getClickSofas()
        {
            return clickSofas;
        }
        //img[@alt='Darcy Sofa, Cobblestone, large']
        [FindsBy(How = How.XPath, Using = "//img[@alt='Darcy Sofa, Cobblestone, large']")]
        private IWebElement selectItem;

        public IWebElement getSelectItem()
        {
            return selectItem;
        }
        //add-to-cart
        [FindsBy(How = How.Id, Using = "add-to-cart")]
        private IWebElement addToCart;

        public IWebElement getAddToCart()
        {
            return addToCart;
        }
        //a[@aria-label='View Shopping Cart']
        [FindsBy(How = How.XPath, Using = "//a[@aria-label='View Shopping Cart']")]
        private IWebElement cartIcon;

        public IWebElement getCartIcon()
        {
            return cartIcon;
        }

        //button[@value='Secure Checkout']
        [FindsBy(How = How.XPath, Using = "//button[@value='Secure Checkout']")]
        private IWebElement secureCheckout;

        public IWebElement getSecureCheckout()
        {
            return secureCheckout;
        }

        /*driver.FindElement(By.XPath("(//input[@type='text'])[1]")).SendKeys("FirstName");
        driver.FindElement(By.XPath("(//input[@type='text'])[2]")).SendKeys("LastName");
        driver.FindElement(By.XPath("(//input[@type='text'])[3]")).SendKeys("100 Main Street");
        driver.FindElement(By.XPath("(//input[@type='text'])[5]")).SendKeys("Tampa");

        SelectElement s = new SelectElement(driver.FindElement(By.Id("dwfrm_singleshipping_shippingAddress_addressFields_states_state")));
        s.SelectByText("Florida");
            driver.FindElement(By.XPath("(//input[@type='tel'])[2]")).SendKeys("8132506272");
        driver.FindElement(By.XPath("(//input[@type='email'])[1]")).SendKeys("autotester803@gmail.com");

        driver.FindElement(By.XPath("//span[text()='Continue as Guest']")).Click();*/

        [FindsBy(How = How.XPath, Using = "(//input[@type='text'])[1]")]
        private IWebElement Firstname;
        [FindsBy(How = How.XPath, Using = "(//input[@type='text'])[2]")]
        private IWebElement Lastname;
        [FindsBy(How = How.XPath, Using = "(//input[@type='text'])[3]")]
        private IWebElement Address;
        [FindsBy(How = How.XPath, Using = "(//input[@type='text'])[5]")]
        private IWebElement City;
        [FindsBy(How = How.XPath, Using = "(//input[@type='tel'])[2]")]
        private IWebElement Phone;
        [FindsBy(How = How.Id, Using = "dwfrm_singleshipping_shippingAddress_addressFields_states_state")]
        private IWebElement State;
        [FindsBy(How = How.XPath, Using = "(//input[@type='email'])[1]")]
        private IWebElement Email;
        [FindsBy(How = How.XPath, Using = "//span[text()='Continue as Guest']")]
        private IWebElement Guest;

        public void DeliveryDetails(String first, String last, String address, String city, String state, String phone, String email)
        {
            Firstname.SendKeys(first);
            Lastname.SendKeys(last);
            Address.SendKeys(address);
            City.SendKeys(city);
            DropDownByText(State,state);
            Phone.SendKeys(phone);
            Email.SendKeys(email);
            Guest.Click();
            
        }

        /* driver.FindElement(By.Id("dwfrm_billing_paymentMethods_creditCard_owner")).SendKeys("FirstName");
         driver.FindElement(By.Id("dwfrm_billing_paymentMethods_creditCard_number")).SendKeys("4000000000000002");

         SelectElement s1 = new SelectElement(driver.FindElement(By.Id("dwfrm_billing_paymentMethods_creditCard_expiration_month")));
         s1.SelectByText("December");

             SelectElement s2 = new SelectElement(driver.FindElement(By.Id("dwfrm_billing_paymentMethods_creditCard_expiration_year")));
         s2.SelectByText("2022");

             driver.FindElement(By.Id("dwfrm_billing_paymentMethods_creditCard_cvn")).SendKeys("382");

         driver.FindElement(By.XPath("(//span[text()='Continue to Order Review'])[1]")).Click();*/

        [FindsBy(How = How.Id, Using = "dwfrm_billing_paymentMethods_creditCard_owner")]
        private IWebElement CCFirstname;

        [FindsBy(How = How.Id, Using = "dwfrm_billing_paymentMethods_creditCard_number")]
        private IWebElement CCCardNO;

        [FindsBy(How = How.Id, Using = "dwfrm_billing_paymentMethods_creditCard_expiration_month")]
        private IWebElement CCExpireMonth;

        [FindsBy(How = How.Id, Using = "dwfrm_billing_paymentMethods_creditCard_expiration_year")]
        private IWebElement CCExpireYear;

        [FindsBy(How = How.Id, Using = "dwfrm_billing_paymentMethods_creditCard_cvn")]
        private IWebElement CCCardCVV;

        [FindsBy(How = How.XPath, Using = "//span[text()='Continue to Order Review']")]
        private IWebElement OrderContinue;

        public void CreditCardDetails(String ccfirstname, String cardno, String month, String year, String cvv)
        {
            CCFirstname.SendKeys(ccfirstname);
            CCCardNO.SendKeys(cardno);
            DropDownByText(CCExpireMonth,month);
            DropDownByText(CCExpireYear, year);
            CCCardCVV.SendKeys(cvv);
         
        }
        public IWebElement getOrderContinue()
        {
            return OrderContinue;
        }

        //button[@value='Place Order']
        [FindsBy(How = How.XPath, Using = "//button[@value='Place Order']")]
        private IWebElement placeOrderBtn;
        public IWebElement getPlaceOrder()
        {
            return placeOrderBtn;
        }





    }
}
