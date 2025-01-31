﻿using CommunityToolkit.Mvvm.ComponentModel;
using AppMAUI_TP6.Service;
using CommunityToolkit.Mvvm.Input;
using AppMAUI_TP6.Models;

namespace AppMAUI_TP6.ViewModel
{

    public partial class CrearProductoViewModel: BaseViewModel
    {
        private readonly ProductoService _service;

        [ObservableProperty]
        Producto producto;
        
        public CrearProductoViewModel()
        {
            Title = "Crear Productos";
            _service = new ProductoService();
            Producto = new Producto();
        }
        [RelayCommand]
        private async Task Crear()
        {
            try
            {
                await _service.CrearProducto(Producto);   
                await Application.Current.MainPage.DisplayAlert("Exito", "Producto creado", "OK");
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
