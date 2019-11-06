using OpenQA.Selenium;
using YoutubeModels.Exceptions;
using YoutubeCoreInterfaces;
using YoutubeModels.Options;
using Microsoft.Extensions.Options;

namespace YoutubeModels.Pages
{
    public class YoutubeMainPage: IYoutubeMainPage
    {               
        private IWebDriver _driver;
        private readonly IWaiter _waiter;
        private readonly IPageActions _pageActions;
        private readonly YoutubeMainPageOptions _options;

        public string Url => _options.MainPageUrl;

        public YoutubeMainPage(IWaiter waiter, IPageActions pageActions, IOptions<YoutubeMainPageOptions> options)
        {                        
            _waiter = waiter;
            _pageActions = pageActions;
            _options = options.Value;
        }

        public void SetWebDriver(IWebDriver driver)
        {
            if (driver == null)
                throw new NullObjectException();                        

            if (driver.Url != _options.MainPageUrl)
                throw new WrongPageException();

            _driver = driver;
        }

        public void GoToTheTrendingPage()
        {
            var trendingLocator = By.XPath(_options.TrendingButtonXPath);
            _waiter.WaitUntillElementBecomeVisible(_driver, trendingLocator);
            var trendingElement = _driver.FindElement(trendingLocator);
            trendingElement.Click();
        }        

        public void WriteTextIntoTheSearchForAVideoSection(string searchVideo)
        {
            var searchInputElement = _pageActions.GetElementById(_driver, _options.SearchInputElementId);
            searchInputElement.SendKeys(searchVideo);
        }

        public void ClickTheSearchVideoButton()
        {
            var searchButton = _pageActions.GetElementById(_driver, _options.SearchButtonEleementId);
            searchButton.Click();
        }
    }
}
