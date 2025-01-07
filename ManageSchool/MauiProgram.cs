﻿using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using ManageSchool.Services;
using ManageSchool.ViewModels;
using ManageSchool.Views;
using ManageSchool.Handlers;
using UraniumUI;

namespace ManageSchool
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseUraniumUI()
                .UseUraniumUIMaterial()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddTransient<JwtTokenHandler>();

            builder.Services.AddHttpClient<IAuthService, AuthService>()
                            .AddHttpMessageHandler<JwtTokenHandler>(); // Handler that attaches token to the Authorization Header

            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<MainPage>();

            builder.Services.AddTransient<RegisterViewModel>();
            builder.Services.AddTransient<RegisterPage>();

            builder.Services.AddTransient<ManagePage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
