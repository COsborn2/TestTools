using IntelliTect.TestTools.Selenate;
using SimpleExamples.Harness;
using System;
using System.Linq;
using Xunit;

namespace SimpleExamples
{
    public class SimpleExampleTests : IDisposable
    {

        // Convert to tests for real websites.
        // For scenarios I can't do on IntelliTect's site, try:
        // http://the-internet.herokuapp.com/
        // https://www.ultimateqa.com/automation/ <-- Unique page seems to be automate an application that evolves over time
        // https://demoqa.com/ <-- Doesn't seem to have anything over the-internet.herokuapp.com
        // http://automationpractice.com/index.php <-- Maybe for demonstrating end-to-end tests?
        // https://www.telerik.com/support/demos <-- Might be good for multi-language testing? Check out ConversationUI
        // https://restful-booker.herokuapp.com/ <-- for API tests

        public SimpleExampleTests()
        {
            Browser = new Browser(BrowserType.Chrome);
            Element = new ElementHandler(Browser.Driver);
            AddRemovePage = new AddRemoveElementsPage(Browser);
        }

        // Testing against http://the-internet.herokuapp.com/add_remove_elements/
        [Fact]
        public void StartWithNoElements()
        {
            Browser.Driver.Navigate().GoToUrl(AddRemovePage.Url);
            Element.WaitForEnabledState(AddRemovePage.AddElementButton);
            Assert.Equal(0, AddRemovePage.AddedElementsList.Count);
        }

        [Fact]
        public void AddOneElement()
        {
            Browser.Driver.Navigate().GoToUrl(AddRemovePage.Url);
            Element.WaitForEnabledState(AddRemovePage.AddElementButton);
            AddRemovePage.AddElementButton.Click();
            Assert.Equal(1, AddRemovePage.AddedElementsList.Count);
        }

        [Fact]
        public void RemoveOneElement()
        {
            Browser.Driver.Navigate().GoToUrl(AddRemovePage.Url);
            Element.WaitForEnabledState(AddRemovePage.AddElementButton);
            AddRemovePage.AddElementButton.Click();
            Element.WaitForEnabledState(AddRemovePage.AddedElementsList.First());
            AddRemovePage.AddedElementsList.First().Click();
            Assert.False(Element.WaitForVisibleState(AddRemovePage.AddedElementsList.First()));
        }

        public void Dispose()
        {
            Browser.Dispose();
        }

        private Browser Browser { get; }
        private ElementHandler Element { get; }
        private AddRemoveElementsPage AddRemovePage { get; }
    }
}
