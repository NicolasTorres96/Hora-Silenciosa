using Hs.Utilidades;
using Hs.Vistas;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Hs
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			//Se debe especificar este valor desde el inicio para posteriormente utilizar sin errores esta clase estatica
			//ExceptionsMessages.app = this;
			if (Variables_Globales.Usuario_Logeado())
			{
				//se redirige a pagina de login
				MainPage = new ListaHS(Variables_Globales.Usuario_Actual);
			}
			else
			{
				MainPage = new MainPage();
			}
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
