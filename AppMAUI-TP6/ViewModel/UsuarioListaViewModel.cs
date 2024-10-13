using AppMAUI_TP6.Models;
using AppMAUI_TP6.Service;
using AppMAUI_TP6.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AppMAUI_TP6.ViewModel
{
    public partial class UsuarioListaViewModel : BaseViewModel
    {
        private readonly UsuarioService _usuarioService;
        public ObservableCollection<Usuario> Usuarios { get; } = new();

        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        Usuario usuarioSeleccionado;



        public UsuarioListaViewModel(UsuarioService usuarioService)
        {
            Title = "Lista de Usuarios";
            _usuarioService = usuarioService;
        }

        [RelayCommand]
        private async Task GetUsuariosAsync()
        {
            if (!IsBusy)
            {
                try
                {
                    IsBusy = true;

                    var usuarios = await _usuarioService.GetListaUsuario();

                    if (usuarios != null)
                    {
                        if (Usuarios.Count != 0)
                            Usuarios.Clear();

                        foreach (var usuario in usuarios)
                            Usuarios.Add(usuario);
                    }

                    IsBusy = false;
                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Error!", ex.Message, "Ok");
                }
                finally
                {
                    IsBusy = false;
                }

            }
        }

        [RelayCommand]
        private async Task GoToDetail()
        {
            if (usuarioSeleccionado == null)
            {
                return;
            }

            await Application.Current.MainPage.Navigation.PushAsync(new UsuarioDetallePage(usuarioSeleccionado), true);
        }
    }   
}
