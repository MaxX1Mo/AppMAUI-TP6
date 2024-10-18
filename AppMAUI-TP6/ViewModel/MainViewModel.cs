
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppMAUI_TP6.Views;


namespace AppMAUI_TP6.ViewModel
{
    public partial class MainViewModel : BaseViewModel
    {

        public MainViewModel()
        {
            Title = "PCGaming Store";
        }

        [RelayCommand]
        public async Task GoToProductoLista()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ProductoListaPage());
        }

        [RelayCommand]
        public async Task GoToAcerca()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AcercaPage());
        }
        [RelayCommand]
        public async Task GoToUsuarioLista()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new UsuarioListaPage());
        }
        //[RelayCommand]
        //public async Task GoToCarritoLista()
        //{
        //    await Application.Current.MainPage.Navigation.PushAsync(new CarritoListaPage());
        //}
        
        
        [RelayCommand]
        public async Task Exit()
        {
            bool confirm = await App.Current.MainPage.DisplayAlert("Confirmar", "¿Estás seguro de salir?", "Sí", "No");

            if (confirm)
            {
                 SecureStorage.Remove("auth_token");
                 await Application.Current.MainPage.Navigation.PopAsync();
            }            

        }


    }

}
