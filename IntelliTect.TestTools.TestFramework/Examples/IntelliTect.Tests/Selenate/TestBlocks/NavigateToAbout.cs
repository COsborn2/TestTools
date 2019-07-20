using System;
using System.Collections.Generic;
using System.Text;
using IntelliTect.TestTools.Selenate;
using Xunit;

namespace IntelliTect.Tests.Selenate.TestBlocks
{
    public class NavigateToAbout : BaseTestBlock
    {
        public NavigateToAbout(Browser browser) : base(browser) { }

        public void Execute()
        {
            HomePage.About.Click();
            Assert.Equal("About", HomePage.AboutPage.Heading.Text);
        }
    }
}
