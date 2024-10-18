using AppMAUI_TP6.Models;
using AppMAUI_TP6.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppMAUI_TP6.ViewModel
{
    public partial class EditarProductoViewModel : BaseViewModel
    {
        private readonly ProductoService _productoService;
        [ObservableProperty]
        Producto producto;

        public EditarProductoViewModel(Producto producto)
        {
            Title = "Editar Producto";
            _productoService = new ProductoService();
            Producto = producto;
        }
        [RelayCommand]
        public async Task GuardarProductoAsync()
        {
            try
            {
                await _productoService.EditarProducto(Producto);
                await Application.Current.MainPage.DisplayAlert("Exito", "Producto guardado correctamente", "OK");
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Hubo un problema: {ex.Message}", "OK");
            }
        }
        [RelayCommand]
        public async Task GoBackAsync()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
