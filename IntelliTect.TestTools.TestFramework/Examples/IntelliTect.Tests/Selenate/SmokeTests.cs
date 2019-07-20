using IntelliTect.TestTools.Selenate;
using IntelliTect.TestTools.TestFramework;
using Xunit;

namespace IntelliTect.Tests.Selenate
{
    public class SmokeTests
    {
        [Fact]
        public void VerifyHomePageLoads()
        {
            TestBuilder builder = new TestBuilder();
            builder.AddDependencyService<Browser>(new BrowserFactory(BrowserType.Chrome).Browser)
                .AddTestBlock<TestBlocks.VerifyHomePageLoads>()
                .ExecuteTestCase();
        }
    }
}
