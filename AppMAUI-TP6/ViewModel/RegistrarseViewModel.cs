using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppMAUI_TP6.Service;
using AppMAUI_TP6.Views;


namespace AppMAUI_TP6.ViewModel
{
    public partial class RegistrarseViewModel : BaseViewModel
    {
        private readonly Login _login;
        [ObservableProperty]
        private string email;
        [ObservableProperty]
        private string username;
        [ObservableProperty]
        private string password;
        [ObservableProperty]
        private string confirmarPassword;

        //el rol no se agrega ya que es un registro de usuario, y sino cualquiera podria ponerse como rol admin
        // entonces utilizo otro endpoint dedicado que el rol pone como defecto como usuario
        //[ObservableProperty]
        //private string rol;
        [ObservableProperty]
        private string nombre;
        [ObservableProperty]
        private string apellido;
        [ObservableProperty]
        private string nrocelular;



        public RegistrarseViewModel()
        {
            _login = new Login();
        }

        [RelayCommand]
        private async Task Registrar()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(ConfirmarPassword) || string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Apellido) || string.IsNullOrEmpty(Nrocelular))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Falta campos por completar!!", "OK");
                return;
            }
            if (password != confirmarPassword)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Las contraseñas no coinciden", "OK");
                return;
            }

            var response = await _login.RegistrarAsync(email,username,password,nombre,apellido,nrocelular);

            if (response)
            {
                await Application.Current.MainPage.DisplayAlert("Éxito", "Usuario registrado con éxito", "OK");
                await Application.Current.MainPage.Navigation.PopAsync(); 
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Hubo un problema con el registro", "OK");
            }
        }

        [RelayCommand]
        private async Task Volver()
        {
            // Comando para volver a la página de Login
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }

}
