using Hs.Clases;
using Hs.Data;
using Hs.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hs.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Registro : ContentPage
	{
		UsuarioData registroUser = new UsuarioData();
		ClubBiblicoData clubesRest = new ClubBiblicoData();
		public Registro()
		{
			InitializeComponent();
			PreparaPantalla();
		}

		private async void PreparaPantalla()
		{
			await cargaCombo();
		}

		private async Task cargaCombo()
		{
			cboCB.ItemsSource = await clubesRest.ListarCB();
			cboCB.ItemDisplayBinding = new Binding("Descripcion");
		}

		public async void Registrarse(object sender, EventArgs args)
		{
			long resultado = 0;
			try
			{
				if (ValidaCampos())
				{
					UsuarioClass usuario = new UsuarioClass();
					usuario.rut = txtRut.Text;
					usuario.nombreCompleto = txtNombre.Text;
					usuario.correo = txtCorreo.Text;
					usuario.contrasena = txtContra.Text;
					usuario.cb = (cboCB.SelectedItem as ClubBiblicoClass).Descripcion;

					resultado = await registroUser.RegistroUsuario(usuario);
					if (resultado == 1)
					{
						DependencyService.Get<Toast>().Show("Registro correcto");
					}
					else
					{
						DependencyService.Get<Toast>().Show("Error en el Registro");
					}

				}
			}
			catch (Exception ex)
			{
				DependencyService.Get<Toast>().Show("Error en el Registro");
			}
		}

		private bool ValidaCampos()
		{
			if ((txtCorreo.Text == null) || (!txtCorreo.Text.Contains("@") && txtCorreo.Text != null))
			{
				DependencyService.Get<Toast>().Show("Ingrese un correo valido");
				return false;
			}
			if (txtNombre.Text == null)
			{
				DependencyService.Get<Toast>().Show("Ingresa tu Nombre Completo");
				return false;
			}
			if (txtContra.Text == null)
			{
				DependencyService.Get<Toast>().Show("Ingresa tu Contraseña");
				return false;
			}
			if (txtContra.Text.Length < 5)
			{
				DependencyService.Get<Toast>().Show("La Contraseña debe tener una longitud de 5 o más caracteres");
				return false;
			}
			if (txtRut.Text == null)
			{
				DependencyService.Get<Toast>().Show("Ingresa tu rut sin puntos ni guion");
				return false;
			}
			if (cboCB.SelectedIndex < 0)
			{
				DependencyService.Get<Toast>().Show("Selecciona tu Club Biblico");
				return false;
			}
			return true;
		}

		private string DevuelveDigitoVerificador(int rut)
		{
			int suma = 0;
			int multiplicador = 1;
			while (rut != 0)
			{
				multiplicador++;
				if (multiplicador == 8)
					multiplicador = 2;
				suma += (rut % 10) * multiplicador;
				rut = rut / 10;
			}
			suma = 11 - (suma % 11);
			if (suma == 11)
			{
				return "0";
			}
			else if (suma == 10)
			{
				return "K";
			}
			else
			{
				return suma.ToString();
			}
		}

		private void TxtRut_Unfocused(object sender, FocusEventArgs e)
		{
			try
			{
				txtRut.MaxLength = 10;
				txtRut.Text = txtRut.Text + "-" + DevuelveDigitoVerificador(int.Parse(txtRut.Text));
			}
			catch (FormatException ex)
			{
				DependencyService.Get<Toast>().Show("Ingresa tu rut sin puntos ni guion");
			}
			catch (NullReferenceException ex)
			{
				DependencyService.Get<Toast>().Show("Ingresa tu rut sin puntos ni guion");
			}
			catch (Exception ex)
			{
				DependencyService.Get<Toast>().Show(ex.GetType().ToString());
			}

		}

		private void TxtRut_Focused(object sender, FocusEventArgs e)
		{
			txtRut.MaxLength = 8;
		}
	}
}