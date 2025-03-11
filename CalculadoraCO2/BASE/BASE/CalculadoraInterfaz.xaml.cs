using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Xamarin.Forms;
using BASE.Model;
using static System.Net.Mime.MediaTypeNames;

namespace BASE
{
    public partial class CalculadoraInterfaz : ContentPage
    {
        public CalculadoraInterfaz()
        {
            InitializeComponent();
            BtnGuardar.Clicked += BtnGuardar_Clicked;
            BtnObtenerCalculos.Clicked += BtnObtenerCalculos_Clicked;
            BtnBorraInformacion.Clicked += BtnBorraInformacion_Clicked;

            tb1.Clicked += Tb1_Clicked;
            tb3.Clicked += Tb3_Clicked;
            BtnContinuacionCalculo.Clicked += BtnContinuacionCalculo_Clicked;
            
        }

        private void BtnBorraInformacion_Clicked(object sender, EventArgs e)
        {
            CalculateRepository.Instancia.DeleteCalculations();

            StatusMessage.Text = CalculateRepository.Instancia.EstadoMensaje;
        }

        private void BtnContinuacionCalculo_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new CrearCalculosInterfaz());
        }


        private void Tb3_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("¿Cómo se calcula la Huella de Carbono?", "\nHUELLA DE CARBONO = Dato Actividad x Factor Emisión \n\n\n -Donde el dato de actividad es la medida que define el nivel de la actividad generadora de las emisiones de gases de efecto invernadero.\n\n\n -Y el factor de emisión es la cantidad de gases de efecto invernadero emitidos por cada unidad medida del dato de actividad.", "OK");
        }

        private void Tb1_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new MenuSecundario());
        }
       

        private void BtnObtenerCalculos_Clicked(object sender, EventArgs e)
        {
            var allUsers = CalculateRepository.Instancia.GetAllCalculates(); 
	        CalculadoraList.ItemsSource = allUsers; StatusMessage.Text = 
		    CalculateRepository.Instancia.EstadoMensaje;
        }

        private void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            StatusMessage.Text = string.Empty;

            //Convertir los valores de texto a flotantes 
	    
	       
            CalculateRepository.Instancia.AddNewCalculate(txtId.Text, txtOrganizationName.Text, txtEmisionType.Text,txtEmisionName.Text);
            StatusMessage.Text = CalculateRepository.Instancia.EstadoMensaje;
            txtId.Text = "";
            txtOrganizationName.Text = "";
            txtEmisionType.Text = "";
            txtEmisionName.Text = "";
           


        }

    }
}