using IntelliTect.TestTools.Selenate;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestFrameworkExamples
{
    public class BrowserFactory
    {
        public BrowserFactory(BrowserType browserType)
        {
            _BrowserType = browserType;
            Browser = GetBrowser;
        }

        public Func<IServiceProvider, Browser> Browser { get; private set; }

        private Browser GetBrowser(IServiceProvider service)
        {
            if (_BrowserType == BrowserType.Chrome)
                return new Browser(BrowserType.Chrome);
            else
                return new Browser(BrowserType.Chrome);
        }

        private BrowserType _BrowserType;
    }
}
