using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using ManageSchool.Services;
using ManageSchool.ViewModels;
using ManageSchool.Views;

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
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddHttpClient<IAuthService,AuthService>();

            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<MainPage>();

            builder.Services.AddSingleton<RegisterViewModel>();
            builder.Services.AddSingleton<RegisterPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
