using AppMAUI_TP6.Service;
using AppMAUI_TP6.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppMAUI_TP6.Views;

namespace AppMAUI_TP6.ViewModel
{
    public partial class UsuarioDetalleViewModel : BaseViewModel
    {
        [ObservableProperty]
        Usuario usuario;

        private readonly UsuarioService _usuarioService;

        public UsuarioDetalleViewModel(UsuarioService usuarioService)
        {
            Title = "Detalle de Usuarios";
            _usuarioService = usuarioService;
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        [RelayCommand]
        public async Task EliminarAsync(int id)
        {
            try
            {
                bool confirm = await App.Current.MainPage.DisplayAlert("Confirmar", "¿Estás seguro de eliminar el usuario?", "Sí", "No");

                if (confirm)
                {
                    await _usuarioService.EliminarUsuario(id);
                    await App.Current.MainPage.DisplayAlert("Éxito", "Usuario eliminado correctamente", "OK");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"Hubo un problema: {ex.Message}", "OK");
            }
        }
        [RelayCommand]
        private async Task EditarUsuario()
        {
            if (Application.Current.MainPage != null)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new EditarUsuarioPage(Usuario));
            }
        }
    }
}
