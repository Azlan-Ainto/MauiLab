using Microsoft.Extensions.Logging;
using TaskSuite.Services;
using TaskSuite.ViewModels;

namespace TaskSuite
{


    //public static MauiApp CreateMauiApp()
    //{
    //    var builder = MauiApp.CreateBuilder();
    //    builder
    //        .UseMauiApp<App>()
    //        .ConfigureFonts(fonts =>
    //        {
    //            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
    //            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
    //        });

    //    // 1. Services registrieren (Singleton = existiert nur einmal in der App)
    //    builder.Services.AddSingleton<ToDoService>();

    //    // 2. ViewModels registrieren
    //    builder.Services.AddSingleton<MainViewModel>();
    //    builder.Services.AddTransient<DetailViewModel>(); // Transient = wird jedes Mal neu erstellt

    //    // 3. Views registrieren (Die erstellen wir in Schritt 6)
    //    builder.Services.AddSingleton<MainPage>();
    //    builder.Services.AddTransient<DetailPage>();

    //    return builder.Build();
    //}



    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


            // 1. Services registrieren (Singleton = existiert nur einmal in der App)
            builder.Services.AddSingleton<ToDoService>();

            // 2. ViewModels registrieren
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddTransient<DetailViewModel>(); // Transient = wird jedes Mal neu erstellt

            // 3. Views registrieren (Die erstellen wir in Schritt 6)
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<DetailPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
