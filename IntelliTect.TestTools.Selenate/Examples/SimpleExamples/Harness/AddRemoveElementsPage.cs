using IntelliTect.TestTools.Selenate;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace SimpleExamples.Harness
{
    public class AddRemoveElementsPage
    {
        public AddRemoveElementsPage(Browser browser)
        {
            Browser = browser;
        }

        public string Url { get; set; } = "http://the-internet.herokuapp.com/add_remove_elements/";

        public IWebElement AddElementButton => Browser.FindElement(By.CssSelector("button[onclick='addElement()']"));
        public IReadOnlyCollection<IWebElement> AddedElementsList => Browser.FindElements(By.CssSelector("div[id='elements']>button"));

        private Browser Browser { get; }
    }
}
