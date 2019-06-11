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
		
		private void Registrarse(object sender, EventArgs e)
		{
			this.Navigation.PushModalAsync(new Registro());
		}

		private void RecuperarPass(object sender, EventArgs e)
		{
			this.Navigation.PushModalAsync(new RecuperaPass());
		}
		
		private async void BtnIniciarSesion_Clicked(object sender, EventArgs e)
		{
			UsuarioClass usuario = new UsuarioClass();
			if (txtContra.Text != null)
			{
				usuario.rut = txtRut.Text;
				usuario.contrasena = txtContra.Text;
				usuario = await loginUser.LoginUsuario(usuario);
			}
			else
			{
				DependencyService.Get<Toast>().Show("Ingrese Contraseña");
				return;
			}

			if (usuario.nombreCompleto == "no se encontró el usuario")
			{
				DependencyService.Get<Toast>().Show("Usuario y/o Contraseña Incorrectos");
				return;
			}
			else
			{
				await this.Navigation.PushModalAsync(new ListaHS(usuario));
			}
		}
	}
}
