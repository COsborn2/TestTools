using IntelliTect.TestTools.Selenate;
using IntelliTect.TestTools.TestFramework;
using Xunit;

namespace IntelliTect.Tests.Selenate
{
    public class NavigationTests
    {
        [Fact]
        public void NavigateToBlogs()
        {
            TestBuilder builder = new TestBuilder();
            builder.AddDependencyService<Browser>(new BrowserFactory(BrowserType.Chrome).Browser)
                .AddTestBlock<TestBlocks.NavigateToBlogs>()
                .ExecuteTestCase();
        }

        [Fact]
        public void NavigateToAbout()
        {
            TestBuilder builder = new TestBuilder();
            builder.AddDependencyService<Browser>(new BrowserFactory(BrowserType.Chrome).Browser)
                .AddTestBlock<TestBlocks.NavigateToAbout>()
                .ExecuteTestCase();
        }
    }
}
