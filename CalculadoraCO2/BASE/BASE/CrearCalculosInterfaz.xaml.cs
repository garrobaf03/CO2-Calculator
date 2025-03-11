using System;
using System.Collections.Generic;
using BASE.Datos;
using BASE.Modelos;
using BASE.ViewModels;
using Xamarin.Forms;

namespace BASE
{	
	public partial class CrearCalculosInterfaz : ContentPage
	{

        CrearCalculosInterfazViewModel viewModel;

        public CrearCalculosInterfaz ()
		{
			InitializeComponent ();
            viewModel = new CrearCalculosInterfazViewModel();
            BindingContext = viewModel;
            
        }

        private void BtnmenuSecundario_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new MenuSecundario());
        }

        private async void OnCalculateClicked(object sender, EventArgs e)
        {
            if (float.TryParse(num1Entry.Text, out float num1) && float.TryParse(num2Entry.Text, out float num2))
            {
                float resultado = num1 * num2;
                resultLabel.Text = resultado.ToString();

                Operacion operacion = new Operacion
                {
                    Num1 = num1,
                    Num2 = num2,
                    Resultado = resultado,
                    Fecha = DateTime.Now
                };

                await OperacionesDatabase.Database.InsertAsync(operacion);
                await viewModel.LoadOperacionesAsync();
            }
        }

        private async void OnDeleteOperacionesClicked(object sender, EventArgs e)
        {
            await viewModel.DeleteOperacionesAsync();
        }

        private async void OnRefreshOperacionesClicked(object sender, EventArgs e)
        {
            await viewModel.RefreshOperacionesAsync();
        }

    }
}

