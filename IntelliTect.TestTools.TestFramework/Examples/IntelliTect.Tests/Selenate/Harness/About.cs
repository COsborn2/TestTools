using IntelliTect.TestTools.Selenate;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace IntelliTect.Tests.Selenate.Harness
{
    public class About : BasePage
    {
        public About(Browser browser) : base(browser) { }

        public override string Url { get; } = "https://intellitect.com/about/";

        public IWebElement Heading => Browser.FindElement(By.CssSelector("h1[class='sc_layouts_title_caption']"));
    }
}
