using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppMAUI_TP6.Models;
using AppMAUI_TP6.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Graphics.Text;

namespace AppMAUI_TP6.ViewModel
{
    public partial class ProductoDetalleViewModel : BaseViewModel
    {
        private readonly CarritoService _carritoService;
        
        [ObservableProperty]
        Producto producto;

        [ObservableProperty]
        string cantidadtext;

        public ProductoDetalleViewModel(CarritoService carritoService)
        {
            Title = "Detalle de Producto";
            _carritoService = carritoService;
        }
        [RelayCommand]
        private async Task AgregarAlCarrito()
        {
            // Validar que la cantidad sea un número y convertirla a entero
            if (!int.TryParse(cantidadtext, out int cantidad) || cantidad <= 0)
            {
                await App.Current.MainPage.DisplayAlert("Cantidad inválida", "Por favor, ingrese una cantidad válida.", "OK");
                return;
            }
            try
            {
                // Verifica que la cantidad no exceda el stock
                if (cantidad > producto.Stock)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "La cantidad solicitada excede el stock disponible.", "OK");
                    return;
                }

                await _carritoService.CrearCarrito(producto.IDProducto, cantidad);
                await App.Current.MainPage.DisplayAlert("Carrito", "Producto agregado al carrito", "OK");

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
        [RelayCommand]
        private async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();

        }

    }
}
