using AppMAUI_TP6.Views;
using AppMAUI_TP6.ViewModel;
namespace AppMAUI_TP6
{
    public partial class App : Application
    {
        public App(LoginViewModel loginViewModel)
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new LoginPage(loginViewModel));
        }
    }
}
