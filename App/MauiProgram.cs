using App.Services;
using App.ViewModels;

namespace App
{
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

            builder.Services.AddSingleton<EventService>();
            
            builder.Services.AddSingleton<EventsViewModel>();

            builder.Services.AddSingleton<MainPage>();
            return builder.Build();
        }
    }
}