using Hs.Clases;
using Hs.Data;
using Hs.Vistas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hs.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaHS : ContentPage
	{
		public ObservableCollection<EncabezadoDiaHsClass> Items { get; set; }
		public DiaHsData diasHsRest = new DiaHsData();
		public List<EncabezadoDiaHsClass> ls = new List<EncabezadoDiaHsClass>();
		public UsuarioClass userGlobal = new UsuarioClass();
		public ListaHS(UsuarioClass user)
		{
			InitializeComponent();
			PreparaPantalla(user);			
		}

		private async void PreparaPantalla(UsuarioClass user)
		{
			lblSaludo.Text = "Hola " + user.nombreCompleto;
			userGlobal = user;
			await cargaLista();
		}

		private async Task cargaLista()
		{
			ls = await diasHsRest.TraerEncabezado(userGlobal.rut);
			llenaLista(ls);
		}

		private void llenaLista(List<EncabezadoDiaHsClass> ls)
		{
			Items = new ObservableCollection<EncabezadoDiaHsClass>();
			foreach (EncabezadoDiaHsClass item in ls)
			{
				Items.Add(item);
			}
			MyListView.ItemsSource = Items;
		}

		async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			if (e.Item == null)
				return;

			await this.Navigation.PushModalAsync(new DiaHsView((EncabezadoDiaHsClass)e.Item));
		}


		private void SbBuscadorDia_TextChanged(object sender, TextChangedEventArgs e)
		{
			var palabra = sbBuscadorDia.Text;

			MyListView.ItemsSource = Items.Where(encabezado => encabezado.dia.ToLower().Contains(palabra));
		}
	}
}
