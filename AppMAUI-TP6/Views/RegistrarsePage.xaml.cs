using AppMAUI_TP6.ViewModel;

namespace AppMAUI_TP6.Views;

public partial class RegistrarsePage : ContentPage
{
	public RegistrarsePage()
	{
		RegistrarseViewModel viewModel = new RegistrarseViewModel();
		InitializeComponent();
		BindingContext = viewModel;
	}
}