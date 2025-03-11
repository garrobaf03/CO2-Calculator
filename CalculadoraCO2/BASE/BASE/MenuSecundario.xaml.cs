using BASE.Model;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BASE
{	
	public partial class MenuSecundario : ContentPage
	{	
		public MenuSecundario ()
		{
			InitializeComponent ();


            tb1.Clicked += Tb1_Clicked;
           
            btnmenuSecundario.Clicked += BtnmenuSecundario_Clicked;
            btncalculadora.Clicked += Btncalculadora_Clicked;
            articuloCO2.Clicked+=ArticuloCO2_Clicked;
            articuloCalentamiento.Clicked+=ArticuloCalentamiento_Clicked;
            btnvideo.Clicked+=Btnvideo_Clicked;
  
        }

        private void Btnvideo_Clicked(object sender, EventArgs e)
        {
            Launcher.OpenAsync(new Uri("https://www.youtube.com/watch?v=8cyAq3AoHhY&t=12s"));
        }

        private void ArticuloCalentamiento_Clicked(object sender, EventArgs e)
        {
            Launcher.OpenAsync(new Uri("https://www.nationalgeographic.com.es/temas/cambio-climatico"));
        }
       
        private void ArticuloCO2_Clicked(object sender, EventArgs e)
        {
            Launcher.OpenAsync(new Uri("https://www.bbc.com/mundo/noticias-50563893"));
        }

        private void Btncalculadora_Clicked(object sender, EventArgs e)
        {
              ((NavigationPage)this.Parent).PushAsync(new CalculadoraInterfaz());;
        }

        private void BtnmenuSecundario_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new MenuOpciones());
        }

        private void Tb1_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new MenuOpciones());
        }
    }
}

