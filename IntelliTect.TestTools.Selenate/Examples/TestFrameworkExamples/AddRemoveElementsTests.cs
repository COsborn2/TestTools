using IntelliTect.TestTools.Selenate;
using IntelliTect.TestTools.TestFramework;
using System;
using Xunit;

namespace TestFrameworkExamples
{
    public class AddRemoveElementsTests
    {
        // Testing against http://the-internet.herokuapp.com/add_remove_elements/

        [Fact]
        public void Test1()
        {
            TestBuilder builder = new TestBuilder();
            builder
                .AddDependencyService<Browser>(new BrowserFactory(BrowserType.Chrome).Browser)
                .AddTestBlock<TestBlocks.NavigateToAddRemovePage>()
                .AddTestBlock<TestBlocks.VerifyNumberOfVisibleElements>(0)
                .ExecuteTestCase();
        }

        [Fact]
        public void AddOneElement()
        {

        }

        [Fact]
        public void AddTwoElements()
        {
  
        }

        [Fact]
        public void RemoveOneElement()
        {

        }
    }
}
