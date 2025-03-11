using BASE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BASE
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Registro : ContentPage
	{
		public Registro()
		{
			InitializeComponent();
            btnRegistar.Clicked += BtnRegistar_Clicked;

            checkboxTerm.CheckedChanged += (s, e) =>
            {
                btnRegistar.IsEnabled = checkboxTerm.IsChecked;
            };
        }

        private void BtnRegistar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idUser.Text))
            {
                DisplayAlert("Error", "Ingrese un número de cédula.", "Ok");
            }

            if (string.IsNullOrWhiteSpace(fullName.Text))
            {
                DisplayAlert("Error", "Ingrese un nombre completo.", "Ok");
            }
            else if (string.IsNullOrWhiteSpace(address.Text))
            {
                DisplayAlert("Error", "Ingrese una dirección.", "Ok");
            }
            else if (string.IsNullOrWhiteSpace(user.Text))
            {
                DisplayAlert("Error", "Ingrese un nombre de usuario.", "Ok");
            }
            else if (string.IsNullOrWhiteSpace(password.Text))
            {
                DisplayAlert("Error", "Ingrese una contraseña.", "Ok");
            }
            else if (string.IsNullOrWhiteSpace(email.Text))
            {
                DisplayAlert("Error", "Ingrese una dirección de correo electrónico.", "Ok");
            }
            else
            {
                UserRegRepository.Instancia.addNewUser(int.Parse(idUser.Text), fullName.Text, address.Text, BirthdatePicker.Date, user.Text, password.Text, email.Text);
                idUser.Text = "";
                fullName.Text = "";
                address.Text = "";
                user.Text = "";
                password.Text = "";
                email.Text = "";

                DisplayAlert("Aviso", "Cuenta creada satisfactoriamente.", "OK");
                ((NavigationPage)this.Parent).PushAsync(new LoginPage());

            }
        }
    }
}