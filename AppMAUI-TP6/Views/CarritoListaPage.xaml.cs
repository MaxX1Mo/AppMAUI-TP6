using AppMAUI_TP6.ViewModel;
using AppMAUI_TP6.Service;

namespace AppMAUI_TP6.Views;

public partial class CarritoListaPage : ContentPage
{
	public CarritoListaPage()
	{
        CarritoService service = new CarritoService();
        CarritoListaViewModel viewModel = new CarritoListaViewModel(service);
        InitializeComponent();
        this.BindingContext = viewModel;
    }

    private void InitializeComponent()
    {
        throw new NotImplementedException();
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        var vm = BindingContext as CarritoListaViewModel;
        if (vm != null)
        {
            await vm.GetCarritosCommand.ExecuteAsync(null);
        }
    }
}