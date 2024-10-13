using AppMAUI_TP6.Service;
using AppMAUI_TP6.ViewModel;
namespace AppMAUI_TP6.Views;

public partial class UsuarioListaPage : ContentPage
{
	public UsuarioListaPage()
	{
        UsuarioService service = new UsuarioService();
        UsuarioListaViewModel vm = new UsuarioListaViewModel(service);
        InitializeComponent();
        this.BindingContext = vm;
    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();

        var vm = BindingContext as UsuarioListaViewModel;
        if (vm != null)
        {
            await vm.GetUsuariosCommand.ExecuteAsync(null);
        }
    }
}