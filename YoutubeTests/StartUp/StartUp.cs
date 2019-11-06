using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using YoutubeCore;
using YoutubeCoreInterfaces;
using YoutubeModels.Helpers;
using YoutubeModels.Options;
using YoutubeModels.Pages;
using YoutubeTests.Options;

namespace YoutubeTests
{
    public class StartUp
    {
        public static IServiceProvider ConfigurateServices()
        {           
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();
            
            var serviceProvider = new ServiceCollection().AddOptions()
                .Configure<YoutubeTestOptions>(config.GetSection("YoutubeTestOptions"))
                .Configure<WaiterOptions>(config.GetSection("WaiterOptions"))
                .Configure<YoutubeMainPageOptions>(config.GetSection("YoutubeMainPageOptions"))
                .Configure<YoutubeOpenedVideoPageOptions>(config.GetSection("YoutubeOpenedVideoPageOptions"))
                .Configure<YoutubeSearchedVideosListPageOptions>(config.GetSection("YoutubeSearchedVideosListPageOptions"))
                .Configure<YoutubeTrendingPageOptions>(config.GetSection("YoutubeTrendingPageOptions"))
                .AddSingleton<IPageActions, PageActions>()
                .AddSingleton<IWaiter, Waiter>()
                .AddSingleton<IYoutubeMainPage, YoutubeMainPage>()
                .AddSingleton<IYoutubeWebSite, YoutubeWebSite>()
                .AddSingleton<IYoutubeTrendingPage, YoutubeTrendingPage>()
                .AddSingleton<IYoutubeOpenedVideoPage, YoutubeOpenedVideoPage>()
                .AddSingleton<IYoutubeSearchedVideosListPage, YoutubeSearchedVideosListPage>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
