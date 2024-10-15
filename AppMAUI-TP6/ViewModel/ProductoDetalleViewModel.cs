using AppMAUI_TP6.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppMAUI_TP6.Service;
namespace AppMAUI_TP6.ViewModel
{
    public partial class ProductoDetalleViewModel : BaseViewModel
    {
        private readonly ProductoService _productoService;

        
        [ObservableProperty]
        Producto producto;
        public ProductoDetalleViewModel(ProductoService productoService)
        {
            _productoService = productoService;
            Title = "Detalles del Producto";
        }

        #region no esta en funcionamiento, la eliminacion funciona pero dando un mensaje de error
        [RelayCommand]
        public async Task GuardarProductoAsync()
        {
            try
            {
                if (producto.IDProducto == 0)
                {
                    // Crear un nuevo producto
                    await _productoService.CrearProducto(producto.NombreProducto, producto.Descripcion, producto.Precio, producto.Imagen, producto.Stock);
                    await App.Current.MainPage.DisplayAlert("Éxito", "Producto creado correctamente", "OK");
                }
                else
                {
                    // Editar producto existente
                    await _productoService.EditarProducto(producto.IDProducto, producto.NombreProducto, producto.Descripcion, producto.Precio, producto.Imagen, producto.Stock);
                    await App.Current.MainPage.DisplayAlert("Éxito", "Producto editado correctamente", "OK");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"Hubo un problema: {ex.Message}", "OK");
            }
        }

        [RelayCommand]
        public async Task EliminarProductoAsync()
        {
            try
            {
                bool confirm = await App.Current.MainPage.DisplayAlert("Confirmar", "¿Estás seguro de eliminar el producto?", "Sí", "No");

                if (confirm)
                {
                    await _productoService.EliminarProducto(producto.IDProducto);
                    await App.Current.MainPage.DisplayAlert("Éxito", "Producto eliminado correctamente", "OK");
                    // Volver a la página anterior
                    await Shell.Current.GoToAsync("..");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"Hubo un problema: {ex.Message}", "OK");
            }
        }
        #endregion

        public ProductoDetalleViewModel()
        {
            Title = "Detalle de Producto";

        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();

        }
    }

}
