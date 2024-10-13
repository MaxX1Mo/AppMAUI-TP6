﻿
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
            Title = "MercadoGamer";
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

        [RelayCommand]
        public async Task Exit()
        {
            await Application.Current.MainPage.DisplayAlert("Salir", "¿Desea terminar la sesión y salir?", "Aceptar");
            SecureStorage.Remove("auth_token");
            await Application.Current.MainPage.Navigation.PopAsync();
        }


    }

}
