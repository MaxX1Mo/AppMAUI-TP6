using AppMAUI_TP6.Models;
using AppMAUI_TP6.ViewModel;
using AppMAUI_TP6.Service;

namespace AppMAUI_TP6.Views;

public partial class CarritoDetallePage : ContentPage
{
	public CarritoDetallePage(Carrito carrito)
	{
        
        CarritoDetalleViewModel viewModel = new CarritoDetalleViewModel();

        InitializeComponent();
        this.BindingContext = viewModel;
        viewModel.Carrito = carrito;
    }

    private void InitializeComponent()
    {
        throw new NotImplementedException();
    }
}