using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppMAUI_TP6.Models;
using AppMAUI_TP6.Service;
namespace AppMAUI_TP6.ViewModel
{
    public partial class CarritoDetalleViewModel : BaseViewModel
    {
        private readonly CarritoService _carritoService;

        [ObservableProperty]
        Carrito carrito;

        public CarritoDetalleViewModel(CarritoService carritoService)
        {
            Title = "Detalle de Carrito";
            _carritoService = carritoService;
        }

        [RelayCommand]
        public async Task EliminarAsync(int id)
        {
            try
            {
                bool confirm = await App.Current.MainPage.DisplayAlert("Confirmar", "¿Estás seguro de eliminar el carrito?", "Sí", "No");

                if (confirm)
                {
                    await _carritoService.EliminarCarrito(id);
                    await App.Current.MainPage.DisplayAlert("Éxito", "Carrito eliminado correctamente", "OK");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"Hubo un problema: {ex.Message}", "OK");
            }
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();

        }
    }
}
