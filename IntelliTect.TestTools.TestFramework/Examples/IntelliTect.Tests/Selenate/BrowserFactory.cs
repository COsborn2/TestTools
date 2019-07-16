using IntelliTect.TestTools.Selenate;
using System;

namespace IntelliTect.Tests.Selenate
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
            return new Browser(_BrowserType);
        }

        private BrowserType _BrowserType;
    }
}
