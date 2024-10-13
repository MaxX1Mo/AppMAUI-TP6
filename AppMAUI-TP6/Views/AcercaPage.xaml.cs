using AppMAUI_TP6.ViewModel;

namespace AppMAUI_TP6.Views;

public partial class AcercaPage : ContentPage
{
	public AcercaPage()
	{
		InitializeComponent();
        AcercaViewModel viewModel = new AcercaViewModel();
        this.BindingContext = viewModel;
    }
}