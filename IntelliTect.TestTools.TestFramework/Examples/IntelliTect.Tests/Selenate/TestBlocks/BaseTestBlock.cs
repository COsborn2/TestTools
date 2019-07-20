using IntelliTect.Tests.Selenate.Harness;
using IntelliTect.TestTools.Selenate;
using IntelliTect.TestTools.TestFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntelliTect.Tests.Selenate.TestBlocks
{
    public class BaseTestBlock : ITestBlock
    {
        public BaseTestBlock(Browser browser)
        {
            Browser = browser;
            HomePage = new HomePage(browser);
            Element = new ElementHandler(browser.Driver);
        }

        protected Browser Browser { get; }
        protected HomePage HomePage { get; }
        protected ElementHandler Element { get; }
    }
}
