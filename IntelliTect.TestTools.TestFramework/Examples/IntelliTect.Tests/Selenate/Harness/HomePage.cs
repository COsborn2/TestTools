using IntelliTect.TestTools.Selenate;
using OpenQA.Selenium;

namespace IntelliTect.Tests.Selenate.Harness
{
    public class HomePage : BasePage
    {
        public HomePage(Browser browser) : base(browser)
        {
            BlogPage = new Blog (browser);
            AboutPage = new About(browser);
        }

        public Blog BlogPage { get; }
        public About AboutPage { get; }

        public override string Url { get; } = "https://intellitect.com";

        public IWebElement Logo => Browser.FindElement(By.CssSelector("section[data-id='d1827a0'] img[class='logo_image']"));
        public IWebElement Blog => Browser.FindElement(By.CssSelector("li[id='menu-item-2485']>a"));
        public IWebElement About => Browser.FindElement(By.CssSelector("li[id='menu-item-8061']>a"));
    }
}
