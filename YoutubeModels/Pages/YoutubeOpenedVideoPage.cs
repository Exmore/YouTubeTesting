using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using YoutubeCoreInterfaces;
using YoutubeModels.Exceptions;
using YoutubeModels.Options;

namespace YoutubeModels.Pages
{
    public class YoutubeOpenedVideoPage: IYoutubeOpenedVideoPage
    {
        private readonly IWaiter _waiter;
        private readonly YoutubeOpenedVideoPageOptions _options;

        private IWebDriver _driver;        
        private IWebElement _likeButton;
        private const string classAttribite = "class";

        public string Url => _options.YoutubeOpenedVideoPageUrl;

        public YoutubeOpenedVideoPage(IWaiter waiter, IOptions<YoutubeOpenedVideoPageOptions> options)
        {
            _waiter = waiter;
            _options = options.Value;
        }

        public string GetCommentsId()
        {
            return _options.CommentsId;
        }

        public void SetWebDriver(IWebDriver driver)
        {
            if (driver == null)
                throw new NullObjectException();            

            if (!driver.Url.Contains(_options.YoutubeOpenedVideoPageUrl))
                throw new WrongPageException();

            _driver = driver;
        }        

        public void ClickLikeButton()
        {
            if (_likeButton == null)
                _likeButton = GetLikeButtonElement();

            _likeButton.Click();
        }

        public bool IsThisVideoLiked()
        {
            if (_likeButton == null)
                _likeButton = GetLikeButtonElement();
            
            var classValue = _likeButton.GetAttribute(classAttribite);
            return classValue.Contains(_options.LikedVideoClassAttribute);
        }

        public void ClickAddAPublickComment()
        {
            if (!AreCommentsAllowed())
                return;

            var publicCommentLocator = By.Id(_options.PublicCommentElementId);
            _waiter.WaitUntillElementBecomeVisible(_driver, publicCommentLocator);
            var publicCommentElement = _driver.FindElement(publicCommentLocator);
            publicCommentElement.Click();
        }

        private IWebElement GetLikeButtonElement()
        {
            var likeBtnLocator = By.XPath(_options.LikeButtonElementXPath);
            _waiter.WaitUntillElementBecomeVisible(_driver, likeBtnLocator);
            return _driver.FindElement(likeBtnLocator);
        }

        private bool AreCommentsAllowed()
        {
            return IsElementExist(_options.BlockedCommetsId) == false;
        }

        private bool IsElementExist(string elementId)
        {
            var locator = By.Id(elementId);
            var elements = _driver.FindElements(locator);
            return elements.Count > 0;
        }       
    }
}
