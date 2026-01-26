using Microsoft.Extensions.Logging;
using DontLeMeExpire.Services;
using DontLeMeExpire.ViewModels;
using DontLeMeExpire.Views;
using CommunityToolkit.Maui;


namespace DontLeMeExpire
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();

#endif
            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddSingleton<ILagerService, LagerService>();
            builder.Services.AddSingleton<IProduktService, ProduktService>();

            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<MainPage>();

            builder.Services.AddTransient<ProduktViewModel>();
           builder.Services.AddTransient<ProduktPage>();

            return builder.Build();
        }
    }
}
