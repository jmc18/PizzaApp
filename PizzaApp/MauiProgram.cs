using Microsoft.Extensions.Logging;

namespace PizzaApp
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
                    Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
#elif STAGING
                    Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Staging");
#elif RELEASE
                    Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Production");
#endif

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
