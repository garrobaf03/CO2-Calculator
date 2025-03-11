using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Net;
using System.Globalization;
using Xamarin.Forms;
using System.Threading;
using BASE.Model;

namespace BASE
{
    public partial class LoginPage : ContentPage
    {

        int intentos = 0;

        public LoginPage()
        {
            InitializeComponent();
            btnIniciarSesion.Clicked += BtnIniciarSesion_Clicked;
            btnRegistar.Clicked += BtnRegistar_Clicked;
        }

        private void BtnRegistar_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Registro());
        }

        private async void BtnIniciarSesion_Clicked(object sender, System.EventArgs e)
        {

            string username = usernametxt.Text;
            string password = passwordtxt.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Error", "Ingrese su nombre de usuario y contraseña.", "Ok");
            }
            else
            {
                bool loginSuc = UserRegRepository.Instancia.loginUser(username, password);

                if (loginSuc)
                {
                    await ((NavigationPage)this.Parent).PushAsync(new MenuOpciones());
                    intentos = 0;
                    usernametxt.Text = "";
                    passwordtxt.Text = "";
                }
                else
                {
                    intentos++;
                    await DisplayAlert("Mensaje", $"Usuario o clave incorrectos. Intento {intentos} de 3", "OK");
                    usernametxt.Text = "";
                    passwordtxt.Text = "";

                    if (intentos == 3)
                    {
                        await DisplayAlert("Atención", "¡Ha superado el límite de intentos permitidos! \n\nLa aplicación se cerrará.", "OK");
                        System.Environment.Exit(0);
                    }
                }

            }


        }
    }
}
