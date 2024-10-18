using AppMAUI_TP6.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppMAUI_TP6.Service;
using AppMAUI_TP6.Views;

namespace AppMAUI_TP6.ViewModel
{
    public partial class ProductoDetalleViewModel : BaseViewModel
    {
        private readonly ProductoService _productoService;
        private readonly CarritoService _carritoService;
        [ObservableProperty]
        Producto producto;

        [ObservableProperty]
        string cantidadtxt;

        public ProductoDetalleViewModel(ProductoService productoService, CarritoService carritoService)
        {
            _productoService = productoService;
            _carritoService = carritoService;
            Title = "Detalles del Producto";
        }

        [RelayCommand]
        public async Task EliminarAsync(int id)
        {
            try
            {
                bool confirm = await App.Current.MainPage.DisplayAlert("Confirmar", "¿Estás seguro de eliminar el producto?", "Sí", "No");

                if (confirm)
                {
                    await _productoService.EliminarProducto(id);
                    await App.Current.MainPage.DisplayAlert("Éxito", "Producto eliminado correctamente", "OK");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"Hubo un problema: {ex.Message}", "OK");
            }
        }
        [RelayCommand]
        private async Task EditarProducto()
        {
            if (Application.Current.MainPage != null)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new EditarProductoPage(Producto));
            }
        }

        [RelayCommand]
        private async Task AgregarAlCarrito()
        {
            // Validar que la cantidad sea un número y convertirla a entero
            if (!int.TryParse(cantidadtxt, out int cantidad) || cantidad <= 0)
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
                await _carritoService.CrearCarrito(Producto, cantidad);
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
