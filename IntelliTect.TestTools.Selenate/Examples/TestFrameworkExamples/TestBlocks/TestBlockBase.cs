using IntelliTect.TestTools.Selenate;
using IntelliTect.TestTools.TestFramework;
using TestFrameworkExamples.PageDefinitions;

namespace TestFrameworkExamples.TestBlocks
{
    public class TestBlockBase : ITestBlock
    {
        public TestBlockBase(Browser browser)
        {
            Browser = browser;
            Element = new ElementHandler(browser.Driver);
            AddRemovePage = new AddRemoveElementsPage(browser);
        }

        protected Browser Browser { get; }
        protected ElementHandler Element { get; }
        protected AddRemoveElementsPage AddRemovePage { get; }
    }
}
