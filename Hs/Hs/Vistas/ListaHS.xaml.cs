using Hs.Clases;
using Hs.Data;
using Hs.Utilidades;
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
		public EncabezadoDiaHsClass[] ls = null;
		public UsuarioClass userGlobal = new UsuarioClass();
		public ListaHS(UsuarioClass user)
		{
			InitializeComponent();
			lblSaludo.Text = "Hola " + user.nombreCompleto;
			userGlobal = user;
		}
		protected async override void OnAppearing()
		{
			base.OnAppearing();
			await CargaLista();
			HacerHsDelDia();
			CargarCombo();
		}

		private void CargarCombo()
		{
			String[] Meses = { "Todos", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
			cboMeses.ItemsSource = Meses;
		}

		private async void HacerHsDelDia()
		{
			String[] fecha;
			String fechaFormateada;
			foreach (var item in Items)
			{
				fecha = item.dia.Split('-');
				if (int.Parse(fecha[1]) < 10)
				{
					if (int.Parse(fecha[2]) < 10)
					{
						fechaFormateada = fecha[2].Replace('0', ' ').Trim() + "/" + fecha[1].Replace('0', ' ').Trim() + "/" + fecha[0];
					}
					else
					{
						fechaFormateada = fecha[2] + "/" + fecha[1].Replace('0', ' ').Trim() + "/" + fecha[0];
					}
					
				}
				else
				{
					if (int.Parse(fecha[2]) < 10)
					{
						fechaFormateada = fecha[2].Replace('0', ' ').Trim() + "/" + fecha[1] + "/" + fecha[0];
					}
					else
					{
						fechaFormateada = fecha[2] + "/" + fecha[1] + "/" + fecha[0];
					}
					
				}

				if (fechaFormateada.Equals(DateTime.Now.ToShortDateString()) && !item.realizada.Equals("lista.png"))
				{
					var ans = await DisplayAlert("Hola " + Variables_Globales.Usuario_Actual.nombreCompleto, "Quieres Hacer la HS del dia?", "Si", "No");
					if (ans)
					{
						await this.Navigation.PushModalAsync(new DiaHsView(item));
					}
				}
			}
		}

		private async Task CargaLista()
		{
			ls = await diasHsRest.TraerEncabezado(userGlobal.rut);
			LlenaLista(ls);
		}

		private void LlenaLista(EncabezadoDiaHsClass[] ls)
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


		/*private void SbBuscadorDia_TextChanged(object sender, TextChangedEventArgs e)
		{
			var palabra = sbBuscadorDia.Text;

			MyListView.ItemsSource = Items.Where(encabezado => encabezado.dia.ToLower().Contains(palabra));
		}*/
		public async void CerrarSesion(object sender, EventArgs args)
		{
			Variables_Globales.Usuario_Actual = null;
			var login = new MainPage();
			await this.Navigation.PushModalAsync(login);
		}

		private void cboMeses_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboMeses.SelectedIndex == 0)
			{
				MyListView.ItemsSource = Items;
			}
			else
			{
				ObservableCollection<EncabezadoDiaHsClass> ItemsFiltrados = new ObservableCollection<EncabezadoDiaHsClass>();
				String[] fecha;				
				foreach (var item in Items)
				{
					fecha = item.dia.Split('-');					
					if (int.Parse(fecha[1]) == cboMeses.SelectedIndex)
					{
						ItemsFiltrados.Add(item);
					}
				}
				MyListView.ItemsSource = ItemsFiltrados;
			}
		}
	}
}
