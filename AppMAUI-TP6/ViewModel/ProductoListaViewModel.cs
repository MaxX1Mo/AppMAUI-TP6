
using AppMAUI_TP6.Models;
using AppMAUI_TP6.Service;
using AppMAUI_TP6.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AppMAUI_TP6.ViewModel
{
    public partial class ProductoListaViewModel : BaseViewModel
    {
        private readonly ProductoService _productoService;

        public ObservableCollection<Producto> Productos { get; } = new();


        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        Producto productoSeleccionado;


        public ProductoListaViewModel(ProductoService productoService)
        {
            Title = "Lista de Productos";
            _productoService = productoService;
        }

        [RelayCommand]
        private async Task GetProductosAsync()
        {
            if (!IsBusy)
            {
                try
                {
                    IsBusy = true;

                    var productos = await _productoService.GetListaProductos();

                    if (productos != null)
                    {
                        if (Productos.Count != 0)
                            Productos.Clear();

                        foreach (var producto in productos)
                            Productos.Add(producto);
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
        private async Task CrearProducto()
        {
            if (Application.Current.MainPage != null)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new CrearProductoPage());
            }
        }

        [RelayCommand]
        private async Task GoToDetail()
        {
            if (productoSeleccionado == null)
            {
                return;
            }

            await Application.Current.MainPage.Navigation.PushAsync(new ProductoDetallePage(productoSeleccionado), true);
        }

    }
}


