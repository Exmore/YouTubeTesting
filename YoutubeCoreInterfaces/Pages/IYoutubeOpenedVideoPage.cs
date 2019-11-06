namespace YoutubeCoreInterfaces
{
    public interface IYoutubeOpenedVideoPage: IWebDriverOwner, IWebPage
    {       
        string GetCommentsId();
        void ClickLikeButton();

        bool IsThisVideoLiked();

        void ClickAddAPublickComment();
    }
}
