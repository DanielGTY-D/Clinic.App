using Clinic.App.Pages;
using Clinic.App.Services;
using Microsoft.Extensions.Logging;

namespace Clinic.App
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

            //Clinic service
            builder.Services.AddScoped<ClinicService>();

            //// Agregar paginas al ServiceProvider
            //builder.Services.AddTransient<MainPage>();
            //builder.Services.AddTransient<RegisterPage>();
            //builder.Services.AddTransient<Login>();
            //builder.Services.AddTransient<MakeAppointmentPage>();
            //builder.Services.AddTransient<AppointmentPage>();

            return builder.Build();
        }
    }
}
