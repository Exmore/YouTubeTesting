using System.Collections.Generic;

namespace YoutubeCoreInterfaces
{
    public interface IYoutubeWebSite: IWebDriverOwner
    {         
        void ScrollToCommentsOnAnOpenedVideoPage();

        void ClickAddAPublickComment();

        void OpenYoutubeMainPage();

        void GoToTheTredingFromMainPage();

        void OpenVideoFromTrendingPage(int videoIndex);

        void ClickLikeButtonOnAnOpenedVideoPage();

        bool IsOpenedVideoLiked();

        void SearchForAVideo(string videoTitle);

        IEnumerable<string> GetUsersListFromVideosListPage();
    }
}
