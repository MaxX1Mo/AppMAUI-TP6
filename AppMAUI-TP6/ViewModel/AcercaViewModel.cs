using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppMAUI_TP6.Views;

namespace AppMAUI_TP6.ViewModel
{
    public partial class AcercaViewModel : BaseViewModel
    {
        public AcercaViewModel()
        {
            Title = "Datos del Programador";
        }


        [RelayCommand]
        public async Task Contact()
        {
            await Application.Current.MainPage.DisplayAlert("Contactar", "Comunicarse con el Programador", "Aceptar");
        }

        [RelayCommand]
        public async Task Volver()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
