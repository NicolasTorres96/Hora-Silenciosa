using Hs.Clases;
using Hs.Data;
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
		LoginUser loginUser = new LoginUser();
		public MainPage()
		{
			InitializeComponent();
		}
		public async void IniciarSesion(object sender, EventArgs args)
		{
			long resultado = 0;

			User usuario = new User();
			usuario.correo = txtCorreo.Text;
			usuario.contraseña = txtContra.Text;

			resultado = await loginUser.LoginUsuario(usuario);
			//if (txtCorreo.Text == "Correo@correo.cl" && txtContra.Text == "1234")
			//{
			//	DisplayAlert("Mensaje", "Sesion Iniciada", "OK");
			//	var nombre = txtCorreo.Text;
			//	var user = new User
			//	{
			//		nombreCompleto = nombre//, por si agrego algo mas
			//	};
			//	this.Navigation.PushModalAsync(new ListaHS(user));
			//}
			//else
			//{
			//	DisplayAlert("Mensaje", "Usuario y/o Contraseña Incorrectos", "OK");
			//}

		}
		private void Registrarse(object sender, EventArgs e)
		{
			this.Navigation.PushModalAsync(new Registro());
		}

		private void RecuperarPass(object sender, EventArgs e)
		{
			this.Navigation.PushModalAsync(new RecuperaPass());
		}
	}
}
