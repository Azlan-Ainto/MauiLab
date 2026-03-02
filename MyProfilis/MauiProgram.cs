using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyProfilis.Data;
using MyProfilis.ViewModel;

namespace MyProfilis
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


#if DEBUG
            builder.Logging.AddDebug();
#endif
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "persons.db");

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite($"Filename={dbPath}"));
            //builder.Services.AddDbContext<AppDbContext>();
            builder.Services.AddTransient<PersonViewModel>();
            builder.Services.AddTransient<DetailViewModel>();
            builder.Services.AddTransient<SearchViewModel>();
            builder.Services.AddTransient<StartPage>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<SearchPage>();         
            builder.Services.AddTransient<DetailViewPage>();


            // Datenbank automatisch erstellen
            using var scope = builder.Build().Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.Database.EnsureCreated();

            return builder.Build();
        }
    }
}

