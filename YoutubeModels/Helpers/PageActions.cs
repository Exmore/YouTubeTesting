using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using YoutubeCoreInterfaces;

namespace YoutubeModels.Helpers
{
    public class PageActions: IPageActions
    {        
        private readonly IWaiter _waiter;
        public PageActions(IWaiter waiter)
        {
            _waiter = waiter;
        }

        public void OpenPage(IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void ScrollToAnElementById(IWebDriver driver, string elementId)
        {
            var locator = By.Id(elementId);
            _waiter.WaitUntillElementBecomeVisible(driver, locator);
            var element = driver.FindElement(locator);

            Actions scrollAction = new Actions(driver);
            scrollAction.MoveToElement(element);
            scrollAction.Perform();
        }

        public IWebElement GetElementById(IWebDriver driver, string elementId)
        {
            var locator = By.Id(elementId);
            _waiter.WaitUntillElementBecomeVisible(driver, locator);
            return driver.FindElement(locator);
        }
    }
}