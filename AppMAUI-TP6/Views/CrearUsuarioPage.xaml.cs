using AppMAUI_TP6.ViewModel;
namespace AppMAUI_TP6.Views;

public partial class CrearUsuarioPage : ContentPage
{
	public CrearUsuarioPage()
	{
		CrearUsuarioViewModel viewModel = new CrearUsuarioViewModel();
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}