//using AppMAUI_TP6.ViewModel;
using AppMAUI_TP6.Service;

namespace AppMAUI_TP6.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
        BindingContext = new LoginViewModel(DependencyService.Get<IUsuarioService>());
    }
}