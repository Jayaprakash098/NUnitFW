using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace sample.Utilities
{
    class BaseTest : BaseMethods
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
