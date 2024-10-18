using AppMAUI_TP6.ViewModel;
using AppMAUI_TP6.Models;
using AppMAUI_TP6.Service;

namespace AppMAUI_TP6.Views;

public partial class UsuarioDetallePage : ContentPage
{
	public UsuarioDetallePage(Usuario user)
	{
        UsuarioService service = new UsuarioService();
        UsuarioDetalleViewModel viewModel = new UsuarioDetalleViewModel(service);
        InitializeComponent();
        this.BindingContext = viewModel;
        viewModel.Usuario = user;
    }
}