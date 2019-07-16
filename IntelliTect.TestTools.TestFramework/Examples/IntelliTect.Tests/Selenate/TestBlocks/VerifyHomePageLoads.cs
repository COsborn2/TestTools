using IntelliTect.Tests.Selenate.Harness;
using IntelliTect.TestTools.Selenate;
using IntelliTect.TestTools.TestFramework;
using Xunit;

namespace IntelliTect.Tests.Selenate.TestBlocks
{
    public class VerifyHomePageLoads : ITestBlock
    {
        public VerifyHomePageLoads(Browser browser)
        {
            Browser = browser;
            HomePage = new HomePage(browser);
            Element = new ElementHandler(browser.Driver);
        }

        public void Execute()
        {
            Browser.Driver.Navigate().GoToUrl(HomePage.Url);
            Assert.True(Element.WaitForEnabledState(HomePage.Logo, 15), 
                "Logo never loaded");
        }

        private Browser Browser { get; }
        private HomePage HomePage { get; }
        private ElementHandler Element { get; }
    }
}
