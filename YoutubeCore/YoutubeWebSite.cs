using OpenQA.Selenium;
using System.Collections.Generic;
using System.Diagnostics;
using YoutubeCoreInterfaces;

namespace YoutubeCore
{
    public class YoutubeWebSite: IYoutubeWebSite
    {
        private IWebDriver _driver;

        private readonly IPageActions _pageActions;
        private readonly IYoutubeMainPage _youtubeMainPage;
        private readonly IYoutubeTrendingPage _youtubeTrendingPage;
        private readonly IYoutubeOpenedVideoPage _youtubeOpenedVideoPage;
        private readonly IYoutubeSearchedVideosListPage _youtubeSearchedVideosListPage;

        public YoutubeWebSite(IYoutubeMainPage mainPage, IPageActions pageActions, IYoutubeTrendingPage trendingPage,
            IYoutubeOpenedVideoPage youtubeOpenedVideoPage, IYoutubeSearchedVideosListPage youtubeSearchedVideosListPage)
        {   
            _youtubeMainPage = mainPage;
            _youtubeTrendingPage = trendingPage;
            _youtubeOpenedVideoPage = youtubeOpenedVideoPage;
            _pageActions = pageActions;
            _youtubeSearchedVideosListPage = youtubeSearchedVideosListPage;
        }

        public void SetWebDriver(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ScrollToCommentsOnAnOpenedVideoPage()
        {
            Trace.WriteLine("Scrolling to comments on a opened video page");

            _youtubeOpenedVideoPage.SetWebDriver(_driver);
            _pageActions.ScrollToAnElementById(_driver, _youtubeOpenedVideoPage.GetCommentsId());
        }

        public void ClickAddAPublickComment()
        {
            Trace.WriteLine("Clicking add a public comment");

            _youtubeOpenedVideoPage.SetWebDriver(_driver);
            _youtubeOpenedVideoPage.ClickAddAPublickComment();
        }

        public void OpenYoutubeMainPage()
        {
            Trace.WriteLine("Opening youtube main page");

            _pageActions.OpenPage(_driver, _youtubeMainPage.Url);
        }        

        public void GoToTheTredingFromMainPage()
        {
            Trace.WriteLine("Going to the treding page");
            
            _youtubeMainPage.SetWebDriver(_driver);
            _youtubeMainPage.GoToTheTrendingPage();
        }

        public void OpenVideoFromTrendingPage(int videoIndex)
        {
            Trace.WriteLine("Openinig a video page");

            _youtubeTrendingPage.SetWebDriver(_driver);
            _youtubeTrendingPage.OpenVideoFromTrendingPage(videoIndex);
        }

        public void ClickLikeButtonOnAnOpenedVideoPage()
        {
            Trace.WriteLine("Clicking on the like button");

            _youtubeOpenedVideoPage.SetWebDriver(_driver);
            _youtubeOpenedVideoPage.ClickLikeButton();
        }

        public bool IsOpenedVideoLiked()
        {
            Trace.WriteLine("Checking an opened video like state");

            _youtubeOpenedVideoPage.SetWebDriver(_driver);
            return _youtubeOpenedVideoPage.IsThisVideoLiked();
        }

        public void SearchForAVideo(string videoTitle)
        {
            Trace.WriteLine($"Searching for a \" {videoTitle} \" video");

            _youtubeMainPage.SetWebDriver(_driver);
            _youtubeMainPage.WriteTextIntoTheSearchForAVideoSection(videoTitle);
            _youtubeMainPage.ClickTheSearchVideoButton();
        }

        public IEnumerable<string> GetUsersListFromVideosListPage()
        {
            Trace.WriteLine("Getting users list from videos list page");

            _youtubeSearchedVideosListPage.SetWebDriver(_driver);
            return _youtubeSearchedVideosListPage.GetUsersOnPage();
        }
    }    
}
