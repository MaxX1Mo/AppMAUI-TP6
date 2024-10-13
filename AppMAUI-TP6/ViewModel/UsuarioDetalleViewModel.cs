
using AppMAUI_TP6.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppMAUI_TP6.ViewModel
{
    public partial class UsuarioDetalleViewModel : BaseViewModel
    {
        [ObservableProperty]
        Usuario usuario;

        public UsuarioDetalleViewModel()
        {
            Title = "Detalle de Usuarios";
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
