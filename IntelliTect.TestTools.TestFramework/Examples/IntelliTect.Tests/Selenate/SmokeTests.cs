using IntelliTect.TestTools.Selenate;
using IntelliTect.TestTools.TestFramework;
using Xunit;

namespace IntelliTect.Tests.Selenate
{
    public class UnitTest1
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
