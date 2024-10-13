using Microsoft.Extensions.Logging;
using AppMAUI_TP6.Service;
using AppMAUI_TP6.ViewModel;
using AppMAUI_TP6.Views;
using Microsoft.Extensions.Logging;
using AppMAUI_TP6;
namespace AppMAUI_TP6
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
                    fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialDesignIcons");

                });

            // AddTransient:  Una nueva instancia del servicio se crea cada vez que se solicita.
            // AddSingleton: Se crea una única instancia de la clase en la primera vez que se solicita,
            // y luego esa misma instancia se reutiliza durante toda la vida de la aplicación.
            
            builder.Services.AddSingleton<ProductoService>();
            builder.Services.AddSingleton<UsuarioService>();
            builder.Services.AddSingleton<CarritoService>();

            builder.Services.AddTransient<ProductoListaViewModel>();
            builder.Services.AddTransient<ProductoListaPage>();
            builder.Services.AddTransient<UsuarioDetallePage>();
            builder.Services.AddTransient<UsuarioListaPage>();

            builder.Services.AddSingleton<Login>();
            builder.Services.AddSingleton<LoginViewModel>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
