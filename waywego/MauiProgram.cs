using CommunityToolkit.Maui.Maps;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using DotNetEnv;


namespace waywego
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory;
            int index = path.IndexOf("\\waywego");
            path = path.Substring(0, index+9);

            DotNetEnv.Env.Load(path+".env");
            string smt = Environment.GetEnvironmentVariable("bingmapsapi");
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkitMaps(Environment.GetEnvironmentVariable("bingmapsapi"))
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}