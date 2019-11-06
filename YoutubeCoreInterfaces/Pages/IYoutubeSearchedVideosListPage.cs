using System.Collections.Generic;

namespace YoutubeCoreInterfaces
{
    public interface IYoutubeSearchedVideosListPage : IWebDriverOwner, IWebPage
    {
        IEnumerable<string> GetUsersOnPage();
    }
}
