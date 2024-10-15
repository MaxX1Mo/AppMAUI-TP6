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
       
        
        public CarritoDetalleViewModel()
        {
            Title = "Detalle de Carrito";
            
        }

        [RelayCommand]
        private async Task Eliminar(int id)
        {

            if (!IsBusy)
            {
                try
                {
                    IsBusy = true;

                    await _carritoService.EliminarCarrito(id);

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
        private async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();

        }
    }
}
