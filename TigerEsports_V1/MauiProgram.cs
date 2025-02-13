﻿using Microsoft.Extensions.Logging;
using TigerEsports_V1.Data;
using TigerEsports_V1.Databases;
//using Material.Components.Maui.Extensions;

namespace TigerEsports_V1
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
            //.UseMaterialComponents();

            builder.Services.AddSingleton<UserDatabase>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
