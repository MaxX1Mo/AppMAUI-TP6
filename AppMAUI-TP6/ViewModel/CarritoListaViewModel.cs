using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppMAUI_TP6.Models;
using AppMAUI_TP6.Service;
using AppMAUI_TP6.Views;

namespace AppMAUI_TP6.ViewModel
{
    public partial class CarritoListaViewModel : BaseViewModel
    {
        private readonly CarritoService _carritoService;

        public ObservableCollection<Carrito> Carritos { get; } = new();


        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        Carrito carritoSeleccionado;


        public CarritoListaViewModel(CarritoService carritoService)
        {
            Title = "Lista de Carritos";
            _carritoService = carritoService;
        }
        
        [RelayCommand]
        private async Task GetCarritosAsync()
        {
            if (!IsBusy)
            {
                try
                {
                    IsBusy = true;

                    var carritos = await _carritoService.GetListaCarritos();

                    if (carritos != null)
                    {
                        if (Carritos.Count != 0)
                            Carritos.Clear();

                        foreach (var carrito in carritos)
                            Carritos.Add(carrito);
                    }

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
        private async Task GoToDetail()
        {
            if (carritoSeleccionado == null)
            {
                return;
            }


            await Application.Current.MainPage.Navigation.PushAsync(new CarritoDetallePage(carritoSeleccionado), true);
        }
        
    }
}
