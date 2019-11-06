using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using YoutubeCoreInterfaces;
using YoutubeModels.Exceptions;
using YoutubeModels.Options;

namespace YoutubeModels.Pages
{
    public class YoutubeTrendingPage : IYoutubeTrendingPage
    {                
        private IWebDriver _driver;
        private readonly IWaiter _waiter;
        private readonly YoutubeTrendingPageOptions _options;

        public string Url => _options.YoutubeTrendingPageUrl;

        public YoutubeTrendingPage(IWaiter waiter, IOptions<YoutubeTrendingPageOptions> options)
        {
            _waiter = waiter;
            _options = options.Value;
        }        

        public void OpenVideoFromTrendingPage(int videoIndex)
        {
            var xPathString = _options.VideoXPathLeftPart + videoIndex + _options.VideoXPathRightPart;
            var videoLocator = By.XPath(xPathString);
            _waiter.WaitUntillElementBecomeVisible(_driver, videoLocator);
            var videoElement = _driver.FindElement(videoLocator);
            videoElement.Click();            
        }

        public void SetWebDriver(IWebDriver driver)
        {
            if (driver == null)
                throw new NullObjectException();            

            if (driver.Url != _options.YoutubeTrendingPageUrl)
                throw new WrongPageException();

            _driver = driver;
        }
    }
}
