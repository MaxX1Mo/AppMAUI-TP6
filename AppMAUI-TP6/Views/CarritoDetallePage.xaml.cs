using AppMAUI_TP6.Models;
using AppMAUI_TP6.ViewModel;
using AppMAUI_TP6.Service;

namespace AppMAUI_TP6.Views;

public partial class CarritoDetallePage : ContentPage
{
	public CarritoDetallePage(Carrito carrito)
	{
        CarritoService service = new CarritoService();
        CarritoDetalleViewModel viewModel = new CarritoDetalleViewModel(service);

        InitializeComponent();
        this.BindingContext = viewModel;
        viewModel.Carrito = carrito;
    }
}