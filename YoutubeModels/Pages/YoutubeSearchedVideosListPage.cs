using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using YoutubeCoreInterfaces;
using YoutubeModels.Exceptions;
using YoutubeModels.Options;

namespace YoutubeModels.Pages
{
    public class YoutubeSearchedVideosListPage: IYoutubeSearchedVideosListPage
    {
        private IWebDriver _driver;
        private readonly IPageActions _pageActions;
        private readonly YoutubeSearchedVideosListPageOptions _options;

        public string Url => _options.YoutubeSearchedVideosListPageUrl;

        public YoutubeSearchedVideosListPage(IPageActions pageActions, IOptions<YoutubeSearchedVideosListPageOptions> options)
        {
            _pageActions = pageActions;
            _options = options.Value;
        }

        public IEnumerable<string> GetUsersOnPage()
        {
            var userElement = _pageActions.GetElementById(_driver, _options.ChannelElementId);
            var locator = By.Id(_options.ChannelElementTextId);
            var userElements = userElement.FindElements(locator);
            return userElements.Select(x => x.Text);            
        }

        public void SetWebDriver(IWebDriver driver)
        {
            if (driver == null)
                throw new NullObjectException();
            
            if (!driver.Url.Contains(_options.YoutubeSearchedVideosListPageUrl))
                throw new WrongPageException();

            _driver = driver;
        }
    }
}
