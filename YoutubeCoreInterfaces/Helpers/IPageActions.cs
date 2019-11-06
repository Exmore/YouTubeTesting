using OpenQA.Selenium;

namespace YoutubeCoreInterfaces
{
    public interface IPageActions
    {
        void ScrollToAnElementById(IWebDriver driver, string elementId);
        void OpenPage(IWebDriver driver, string url);
        IWebElement GetElementById(IWebDriver driver, string elementId);
    }
}
