namespace YoutubeCoreInterfaces
{
    public interface IYoutubeMainPage: IWebDriverOwner, IWebPage
    {        
        void GoToTheTrendingPage();
        void WriteTextIntoTheSearchForAVideoSection(string searchVideo);
        void ClickTheSearchVideoButton();
    }
}
