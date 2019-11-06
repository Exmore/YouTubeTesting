using OpenQA.Selenium;

namespace YoutubeCoreInterfaces
{
    public interface IWaiter
    {
        void WaitUntillElementBecomeVisible(IWebDriver driver, By locator);
    }
}
