using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BASE
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuOpciones : ContentPage
	{
		public MenuOpciones ()
		{
			InitializeComponent ();
            btnAyuda.Clicked += BtnAyuda_Clicked;
            btnSalirApp.Clicked += BtnSalirApp_Clicked;
            btnMenuPrincipal.Clicked += BtnMenuPrincipal_Clicked;
            btnCalculadoraCO2.Clicked += BtnCalculadoraCO2_Clicked;
		}

        private void BtnCalculadoraCO2_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new CalculadoraInterfaz());
        }

        private void BtnMenuPrincipal_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new MenuSecundario());
        }

        private async void BtnSalirApp_Clicked(object sender, EventArgs e)
        {

            await DisplayAlert("Mensaje", "Gracias por utilizar la aplicación.", "Ok");
            
            System.Environment.Exit (0);
        }

        private void BtnAyuda_Clicked(object sender, EventArgs e)
        {
            Launcher.OpenAsync(new Uri("https://cambioclimatico.go.cr/"));
        }
    }
}