using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppMAUI_TP6.Service;
using AppMAUI_TP6.ViewModel;
using CommunityToolkit.Mvvm.Input;
using AppMAUI_TP6.Views;
using Microsoft.Maui.Graphics.Text;

namespace AppMAUI_TP6.ViewModel
{
    
    public partial class CrearProductoViewModel: BaseViewModel
    {
        private readonly ProductoService _service;

        [ObservableProperty]
        private string nombreProducto;

        [ObservableProperty]
        private string descripcion;

        [ObservableProperty]
        private decimal precio;

        [ObservableProperty]
        private string imagen;

        [ObservableProperty]
        private int stock;

        public CrearProductoViewModel()
        {
            Title = "Lista de Productos";
            _service = new ProductoService();
        }
        [RelayCommand]
        private async Task Crear()
        {
            try
            {
                await _service.CrearProducto(NombreProducto, descripcion, precio, imagen, stock);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");

            }
        }
        [RelayCommand]
        private async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();

        }
    }
}
