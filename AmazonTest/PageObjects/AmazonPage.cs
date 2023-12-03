using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.PageObjects
{
    class AmazonPage 
    {
        private IWebDriver driver;

        public AmazonPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@dir='auto']")]
        private IWebElement searchTextBox;

        public IWebElement getSearchTextBox()
        {
            return searchTextBox;
        }

        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        private IWebElement searchButton;
        public IWebElement getSearchButton()
        {
            return searchButton;
        }

        [FindsBy(How = How.XPath, Using = "//span[text()='Apple iPhone 13 (128GB) - Midnight']")]
        private IWebElement productiphone;
        public IWebElement getProductiPhone()
        {
            return productiphone;
        }
        [FindsBy(How = How.Id, Using = "add-to-cart-button")]
        private IWebElement cartbutton;
        public IWebElement getCartButton()
        {
            return cartbutton;
        }

        [FindsBy(How = How.XPath, Using = "//a[@id='nav-hamburger-menu']")]
        private IWebElement allMenu;
        public IWebElement getAllMenu()
        {
            return allMenu;
        }

        [FindsBy(How = How.XPath, Using = "//a[@data-menu-id='8']")]
        private IWebElement subMenu;
        public IWebElement getSubMenu()
        {
            return subMenu;
        }

        [FindsBy(How = How.XPath, Using = "//a[text()='Cases & Covers']")]
        private IWebElement casesAndCovers;
        public IWebElement getCaseAndCovers()
        {
            return casesAndCovers;
        }

        [FindsBy(How = How.XPath, Using = "//img[@alt='apple']")]
        private IWebElement appleCase;
        public IWebElement getAppleCase()
        {
            return appleCase;
        }

        [FindsBy(How = How.XPath, Using = "//span[@id='a-autoid-13']")]
        private IWebElement iphone13Case;
        public IWebElement getiPhone13Case()
        {
            return iphone13Case;
        }

        [FindsBy(How = How.XPath, Using = "//img[@alt='Spigen Ultra Hybrid Matte Back Cover Case Compatible with iPhone 13 (TPU + Poly Carbonate | Frost Black)']")]
        private IWebElement selectedcase;
        public IWebElement getSelectedCase()
        {
            return selectedcase;
        }

        [FindsBy(How = How.XPath, Using = "(//span[@class='a-button-inner'])[2]")]
        private IWebElement gotocartButton;
        public IWebElement getGoToCartButton()
        {
            return gotocartButton;
        }

        [FindsBy(How = How.XPath, Using = "//input[@name='proceedToRetailCheckout']")]
        private IWebElement checkoutButton;
        public IWebElement getCheckoutButton()
        {
            return checkoutButton;
        }
    } 
}
