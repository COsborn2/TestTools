using IntelliTect.TestTools.Selenate;
using OpenQA.Selenium;

namespace IntelliTect.Tests.Selenate.Harness
{
    public class HomePage
    {
        public HomePage(Browser browser)
        {
            Browser = browser;
        }

        public string Url { get; } = "https://intellitect.com/";
        public IWebElement Logo => Browser.FindElement(By.CssSelector("section[data-id='d1827a0'] img[class='logo_image']"));

        protected Browser Browser { get; }
    }
}
