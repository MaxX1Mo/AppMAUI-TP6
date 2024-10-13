using AppMAUI_TP6.Views;
using AppMAUI_TP6.ViewModel;

namespace AppMAUI_TP6.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}
