using CommunityToolkit.Mvvm.ComponentModel;
using AppMAUI_TP6.Service;
using CommunityToolkit.Mvvm.Input;
using AppMAUI_TP6.Models;
namespace AppMAUI_TP6.ViewModel
{
    public partial class CrearUsuarioViewModel : BaseViewModel
    {
        private readonly UsuarioService _service;

        [ObservableProperty]
        Usuario usuario;

        public CrearUsuarioViewModel()
        {
            Title = "Crear Usuario";
            _service = new UsuarioService();
            Usuario = new Usuario();
        }
        [RelayCommand]
        private async Task Crear()
        {
            try
            {
                await _service.CrearUsuario(Usuario);
                await Application.Current.MainPage.DisplayAlert("Exito", "Usuario creado", "OK");
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
            await Application.Current.MainPage.DisplayAlert("Error", $"Hubo un problema: {ex.Message}", "OK");
            }
        }
        [RelayCommand]
        private async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }

}
