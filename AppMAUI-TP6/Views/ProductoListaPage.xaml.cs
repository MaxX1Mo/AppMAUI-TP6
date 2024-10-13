using AppMAUI_TP6.ViewModel;
using AppMAUI_TP6.Service;
namespace AppMAUI_TP6.Views;

public partial class ProductoListaPage : ContentPage
{
	public ProductoListaPage()
	{
		ProductoService service = new ProductoService();
        ProductoListaViewModel viewModel = new ProductoListaViewModel(service);
        InitializeComponent();
        this.BindingContext = viewModel;
       
    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();

        var vm = BindingContext as ProductoListaViewModel;
        if (vm != null)
        {
            await vm.GetProductosCommand.ExecuteAsync(null);
        }
    }
}
