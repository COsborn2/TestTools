using IntelliTect.TestTools.Selenate;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace IntelliTect.Tests.Selenate.Harness
{
    public class Blog : BasePage
    {
        public Blog(Browser browser) : base(browser) { }

        public override string Url { get; } = "https://intellitect.com/blog/";

        public IReadOnlyCollection<IWebElement> Articles => Browser.FindElements(By.CssSelector("div[class='blog_archive'] article"));
    }
}
