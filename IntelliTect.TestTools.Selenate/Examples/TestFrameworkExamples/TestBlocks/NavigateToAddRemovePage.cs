using IntelliTect.TestTools.Selenate;
using IntelliTect.TestTools.TestFramework;
using System;
using System.Collections.Generic;
using System.Text;
using TestFrameworkExamples.PageDefinitions;

namespace TestFrameworkExamples.TestBlocks
{
    public class NavigateToAddRemovePage : TestBlockBase
    {
        public NavigateToAddRemovePage(Browser browser) : base(browser) { }

        public void Execute()
        {
            Browser.Driver.Navigate().GoToUrl(AddRemovePage.Url);
            Element.WaitForEnabledState(AddRemovePage.AddElementButton);
        }
    }
}
