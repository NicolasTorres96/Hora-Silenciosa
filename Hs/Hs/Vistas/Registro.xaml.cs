using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HSpdv
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Registro : ContentPage
	{
		public Registro ()
		{
			InitializeComponent ();
            List<String> clubes = new List<string>();
            clubes.Add("La Gracia");
            clubes.Add("Cerrillos");
            clubes.Add("4 Álamos");
            cboCB.ItemsSource = clubes;
		}

        public void Registrarse(object sender, EventArgs args)
        {
            DisplayAlert("Exito","Registro Completo","Aceptar");
        }

    }
}