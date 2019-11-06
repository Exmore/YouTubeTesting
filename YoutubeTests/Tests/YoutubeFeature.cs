using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using System.Diagnostics;
using System.Linq;
using YoutubeTests.Options;
using Microsoft.Extensions.Options;
using YoutubeCoreInterfaces;

namespace YoutubeTests.Tests
{
    [TestClass]
    public class YoutubeFeature
    {
        private IWebDriver _driver;
        private IYoutubeWebSite _youtubePages;
        private YoutubeTestOptions _testOptions;

        [TestInitialize]
        public void DriverInit()
        {            
            var serviceProvider = StartUp.ConfigurateServices();
            
            var options = serviceProvider.GetService<IOptions<YoutubeTestOptions>>();
            _testOptions = options.Value;

            _driver = WebDriverInitializer.InitChromeDriver();

            _youtubePages = serviceProvider.GetService<IYoutubeWebSite>();            
            _youtubePages.SetWebDriver(_driver);
        }
        
        [TestMethod]
        public void LikeBtnWillNotChangeStateAfterClick()
        {
            var videoIndex = _testOptions.LikeCheckTestCaseInfo.VideoIndex;

            Trace.WriteLine($"Starting \"LikeBtnWillNotChangeStateAfterClick\" with params. VideoIndex = {videoIndex}");

            _youtubePages.OpenYoutubeMainPage();
            _youtubePages.GoToTheTredingFromMainPage();
            _youtubePages.OpenVideoFromTrendingPage(videoIndex);
            _youtubePages.ClickLikeButtonOnAnOpenedVideoPage();

            Assert.IsFalse(_youtubePages.IsOpenedVideoLiked());

            Trace.WriteLine($"\"LikeBtnWillNotChangeStateAfterClick\" has finished");
        }

        [TestMethod]
        public void AfterAddCommentBtnPressWillBeRedirect()
        {
            var videoIndex = _testOptions.RedirectCheckTestCaseInfo.VideoIndex;
            var redirectPath = _testOptions.RedirectCheckTestCaseInfo.RedirectPath;

            Trace.WriteLine($"Starting \"AfterAddCommentBtnPressWillBeRedirect\" with params. VideoIndex = {videoIndex}, RedirectPath = {redirectPath}");

            _youtubePages.OpenYoutubeMainPage();
            _youtubePages.GoToTheTredingFromMainPage();
            _youtubePages.OpenVideoFromTrendingPage(videoIndex);
            _youtubePages.ScrollToCommentsOnAnOpenedVideoPage();
            _youtubePages.ClickAddAPublickComment();

            Assert.IsTrue(_driver.Url.Contains(redirectPath));

            Trace.WriteLine($"\"AfterAddCommentBtnPressWillBeRedirect\" has finished");
        }

        [TestMethod]
        public void UserIsFoundedAfterSerchInVideoSection()
        {
            var videoTitle = _testOptions.UserCheckTestCaseInfo.VideoTitle;
            var userTitle = _testOptions.UserCheckTestCaseInfo.UserName;

            Trace.WriteLine($"Starting \"UserIsFoundedAfterSerchInVideoSection\" with params. VideoTitle = {videoTitle}, UserTitle = {userTitle}");

            _youtubePages.OpenYoutubeMainPage();
            _youtubePages.SearchForAVideo(videoTitle);
            var usersList = _youtubePages.GetUsersListFromVideosListPage();
            var neededUser = usersList.FirstOrDefault(x => x == userTitle);

            Assert.IsNotNull(neededUser);

            Trace.WriteLine($"\"UserIsFoundedAfterSerchInVideoSection\" has finished");
        }

        [TestCleanup]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}