using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using YoutubeCoreInterfaces;
using YoutubeModels.Options;

namespace YoutubeModels.Helpers
{
    public class Waiter : IWaiter
    {
        private readonly int _waitSeconds;
        public Waiter(IOptions<WaiterOptions> options)
        {            
            _waitSeconds = options.Value.WaitSeconds;
        }

        public void WaitUntillElementBecomeVisible(IWebDriver driver, By locator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(_waitSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
    }   
}
