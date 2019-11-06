namespace YoutubeCoreInterfaces
{
    public interface IYoutubeTrendingPage: IWebDriverOwner, IWebPage
    {
        void OpenVideoFromTrendingPage(int videoIndex);
    }
}
