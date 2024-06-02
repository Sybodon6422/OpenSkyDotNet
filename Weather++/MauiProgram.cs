using Microsoft.Maui.LifecycleEvents;
using Weather__.Pages;
using Weather__.ViewModels;

namespace Weather__
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
                    fonts.AddFont("fa-solid-900.ttf", "FontAwesome");
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-SemiBold.ttf", "OpenSansSemiBold");
                });
            builder.ConfigureLifecycleEvents(lifecycle =>
            {
            });

            var services = builder.Services;

            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<HomePage>();

            return builder.Build();
        }
    }
}