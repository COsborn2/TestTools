using System;
using System.Collections.Generic;
using System.Text;
using IntelliTect.TestTools.Selenate;
using Xunit;

namespace IntelliTect.Tests.Selenate.TestBlocks
{
    public class NavigateToBlogs : BaseTestBlock
    {
        public NavigateToBlogs(Browser browser) : base(browser) { }

        public void Execute()
        {
            HomePage.Blog.Click();
            Assert.True(HomePage.BlogPage.Articles.Count > 0);
        }
    }
}
