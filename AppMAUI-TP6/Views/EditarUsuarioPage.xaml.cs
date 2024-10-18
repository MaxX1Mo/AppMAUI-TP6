using AppMAUI_TP6.ViewModel;
using AppMAUI_TP6.Models;
namespace AppMAUI_TP6.Views;

public partial class EditarUsuarioPage : ContentPage
{
	public EditarUsuarioPage(Usuario usuario)
	{
		InitializeComponent();
		BindingContext = new EditarUsuarioViewModel(usuario);
	}
}