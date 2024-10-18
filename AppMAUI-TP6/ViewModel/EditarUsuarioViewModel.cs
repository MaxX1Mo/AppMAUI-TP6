using AppMAUI_TP6.Models;
using AppMAUI_TP6.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
namespace AppMAUI_TP6.ViewModel
{
    public partial class EditarUsuarioViewModel : BaseViewModel
    {
        private readonly UsuarioService _usuarioService;
        [ObservableProperty]
        Usuario usuario;

        public EditarUsuarioViewModel(Usuario usuario)
        {
            Title = "Editar Usuario";
            _usuarioService = new UsuarioService();
            Usuario = usuario;
        }
        [RelayCommand]
        public async Task GuardarUsuarioAsync()
        {
            try
            {
                await _usuarioService.EditarUsuario(Usuario);
                await Application.Current.MainPage.DisplayAlert("Exito", "Usuario guardado correctamente", "OK");
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Hubo un problema: {ex.Message}", "OK");
            }

        }
        
        [RelayCommand]
        public async Task GoBackAsync()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}