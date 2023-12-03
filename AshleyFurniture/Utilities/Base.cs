using AshleyFurniture.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager.DriverConfigs.Impl;

namespace AshleyFurniture.Utilities
{
    class Base : BaseClassMethods
    {
        [SetUp]
        public void StartBrowser()
        {
            LaunchBrowser();
            Maximize();
            ImplicitWait();
            Openurl("https://storefront:afweb2017@staging.ashleyfurniture.com/");
            
        }

    }
}
