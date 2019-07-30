using IntelliTect.TestTools.Selenate;
using Xunit;

namespace TestFrameworkExamples.TestBlocks
{
    public class VerifyNumberOfVisibleElements : TestBlockBase
    {
        public VerifyNumberOfVisibleElements(Browser browser) : base(browser) { }

        public void Execute(int numberOfVisibleElements)
        {
            Assert.Equal(numberOfVisibleElements, AddRemovePage.AddedElementsList.Count);
        }
    }
}
