using AppMAUI_TP6.ViewModel;

namespace AppMAUI_TP6.Views;

public partial class CrearProductoPage : ContentPage
{
	public CrearProductoPage()
	{
        CrearProductoViewModel viewModel = new CrearProductoViewModel();
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}