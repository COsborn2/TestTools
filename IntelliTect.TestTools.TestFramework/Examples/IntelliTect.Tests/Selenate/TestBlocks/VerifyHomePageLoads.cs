using IntelliTect.Tests.Selenate.Harness;
using IntelliTect.TestTools.Selenate;
using IntelliTect.TestTools.TestFramework;
using Xunit;

namespace IntelliTect.Tests.Selenate.TestBlocks
{
    public class VerifyHomePageLoads : BaseTestBlock
    {
        public VerifyHomePageLoads(Browser browser) : base(browser) { }

        public void Execute()
        {
            Assert.True(Element.WaitForEnabledState(HomePage.Logo, 15), 
                "Logo never loaded");
        }
    }
}
