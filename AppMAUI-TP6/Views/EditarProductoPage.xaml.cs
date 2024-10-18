using AppMAUI_TP6.ViewModel;
using AppMAUI_TP6.Models;

namespace AppMAUI_TP6.Views;

public partial class EditarProductoPage : ContentPage
{
    public EditarProductoPage(Producto producto)
    {
        InitializeComponent();
        
        BindingContext = new EditarProductoViewModel(producto);
    }

}