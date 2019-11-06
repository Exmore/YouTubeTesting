using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace YoutubeTests
{
    public static class WebDriverInitializer
    {
        public static IWebDriver InitChromeDriver()
        {
            var outPutDirectory = GetOutPutDirectory();
            return new ChromeDriver(outPutDirectory);
        }

        private static string GetOutPutDirectory()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
