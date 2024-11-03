using EasyApp.Services.ConexaoAPI;
using Microsoft.Extensions.Logging;

namespace EasyApp
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
#endif

            builder.Services.AddTransient<IApiService, ApiService>();

            return builder.Build();
        }
    }
}

//testando alteracao git BY PEDRO

