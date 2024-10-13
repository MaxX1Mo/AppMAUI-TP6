using AppMAUI_TP6.Models;
using AppMAUI_TP6.ViewModel;
using AppMAUI_TP6.Service;


namespace AppMAUI_TP6.Views;

public partial class ProductoDetallePage : ContentPage
{
	public ProductoDetallePage(Producto producto)
	{
        //ProductoService service = new ProductoService();
        CarritoService service = new CarritoService();
        ProductoDetalleViewModel viewModel = new ProductoDetalleViewModel(service);
		
		InitializeComponent();
		this.BindingContext = viewModel;
		viewModel.Producto = producto;
	}
}