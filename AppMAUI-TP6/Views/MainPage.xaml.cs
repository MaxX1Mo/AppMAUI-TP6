using AppMAUI_TP6.ViewModel;
namespace AppMAUI_TP6.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        MainViewModel viewModel = new MainViewModel();
        this.BindingContext = viewModel;
    }
}