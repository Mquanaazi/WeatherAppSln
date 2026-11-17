using Microsoft.Extensions.Logging;
using WeatherApp.Interfaces;
using WeatherApp.ViewModels;
using WeatherApp.Views;
using WeatherApp.Services;

namespace WeatherApp
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

#if DEBUG
    		builder.Logging.AddDebug();
            builder.Services.AddSingleton<IConfigurationService, ConfigurationService>();
            builder.Services.AddSingleton<IWeatherHttpApiService, WeatherHttpApiService>();
            builder.Services.AddSingleton<IMauiPopupService, MauiPopupService>();

            builder.Services.AddTransient<HomeViewModel>();
            builder.Services.AddTransient<HomePage>();
#endif

            return builder.Build();
        }
    }
}
