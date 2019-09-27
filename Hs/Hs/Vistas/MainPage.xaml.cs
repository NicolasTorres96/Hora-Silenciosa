using Hs.Clases;
using Hs.Data;
using Hs.Utilidades;
using Hs.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Hs.Vistas
{
	public partial class MainPage : ContentPage
	{
		UsuarioData loginUser = new UsuarioData();
		public MainPage()
		{
			InitializeComponent();
		}
		public async void IniciarSesion(object sender, EventArgs args)
		{
			UsuarioClass usuario = new UsuarioClass();
			if (txtContra.Text != null)
			{
				usuario.rut = txtRut.Text;
				usuario.contrasena = txtContra.Text;
				usuario = await loginUser.LoginUsuario(usuario);
				if (usuario != null)
				{
					Variables_Globales.Usuario_Actual = usuario;
					var lista = new ListaHS(usuario);
					await this.Navigation.PushModalAsync(lista);
				}
				else
				{
					DependencyService.Get<Toast>().Show("Usuario y/o Contraseña Incorrectos");
				}
			}
			else
			{
				DependencyService.Get<Toast>().Show("Ingrese Contraseña");
			}			
		}
		private void Registrarse(object sender, EventArgs e)
		{
			this.Navigation.PushModalAsync(new Registro());
		}

		private void RecuperarPass(object sender, EventArgs e)
		{
			this.Navigation.PushModalAsync(new RecuperaPass());
		}


		private void TxtContra_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (txtContra.Text == "")
			{
				txtContra.Text = null;
			}
		}
	}
}
