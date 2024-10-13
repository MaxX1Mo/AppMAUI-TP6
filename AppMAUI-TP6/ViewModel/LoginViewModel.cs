using AppMAUI_TP6.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppMAUI_TP6.Views;

namespace AppMAUI_TP6.ViewModel
{
    public partial class LoginViewModel : BaseViewModel
    {       
        private readonly Login _login;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string errorMessage;

        [ObservableProperty]
        private bool isErrorVisible;

        public LoginViewModel()
        {
         _login = new Login();   
        }

        [RelayCommand]
        private async Task Acceso()
        {
            IsErrorVisible = false;
            ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                ErrorMessage = "Por favor, introduzca el nombre de usuario y la contraseña.";
                IsErrorVisible = true;
                return;
            }

            try
            {
                var token = await _login.LoginAsync(Email, Password);

                if (!string.IsNullOrEmpty(token))
                {
                    SecureStorage.SetAsync("auth_token", token);
                    await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
                }
                else
                {
                    ErrorMessage = "contraseña o nombre de usuario incorrecto.";
                    IsErrorVisible = true;
                }
            }

            catch (Exception ex)
            {
                ErrorMessage = "Login failed: contraseña o nombre de usuario incorrecto.";
                //ErrorMessage = $"Login failed: {ex.Message}";   para encontrar el error mas exacto

                IsErrorVisible = true;
                
            }
        }
        [RelayCommand]
        private async Task Registrar()
        {
            // Aquí navegas a la página de registro
            await Application.Current.MainPage.Navigation.PushAsync(new RegistrarsePage());
        }
    }
}
