using AppMAUI_TP6.ViewModel;
using AppMAUI_TP6.Models;
namespace AppMAUI_TP6.Views;

public partial class UsuarioDetallePage : ContentPage
{
	public UsuarioDetallePage(Usuario user)
	{
        UsuarioDetalleViewModel viewModel = new UsuarioDetalleViewModel();
        InitializeComponent();
        this.BindingContext = viewModel;
        viewModel.Usuario = user;
    }
}