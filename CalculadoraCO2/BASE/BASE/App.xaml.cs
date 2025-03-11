using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BASE
{
    public partial class App : Application
    {
        public App(string filename)
        {
            InitializeComponent();
            Model.CalculateRepository.Inicializador(filename);
            Model.UserRegRepository.Inicializador(filename);
            MainPage = new NavigationPage(new LoginPage());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
