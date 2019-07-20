using IntelliTect.TestTools.Selenate;

namespace IntelliTect.Tests.Selenate.Harness
{
    public abstract class BasePage
    {
        public BasePage(Browser browser)
        {
            Browser = browser;
            Browser.Driver.Navigate().GoToUrl(Url);
        }

        public abstract string Url { get; }

        protected Browser Browser { get; }
    }
}
