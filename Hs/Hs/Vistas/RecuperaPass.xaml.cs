using Hs.Clases;
using Hs.Data;
using Hs.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hs.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RecuperaPass : ContentPage
	{
		Usuario usuarioRest = new Usuario();
		public RecuperaPass ()
		{
			InitializeComponent ();
		}
		private async void Recuperar(object sender, EventArgs e)
		{
			User user = await traerUsuario();
			
			if (user!= null)
			{
				SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
				MailMessage message = new MailMessage();
				message.From = new MailAddress("contacto.horasilenciosa@gmail.com", "Contacto");
				message.To.Add(user.correo);
				message.Subject = "Recuperación de Contraseña";
				message.Body = BodyMensaje(user);
				message.IsBodyHtml = true;
				client.EnableSsl = true;
				client.DeliveryMethod = SmtpDeliveryMethod.Network;
				client.UseDefaultCredentials = false;
				client.Credentials = new NetworkCredential("contacto.horasilenciosa@gmail.com", "administradorhs");
				client.Send(message);
				DependencyService.Get<Toast>().Show("Correo Enviado");
			}
			else
			{
				DependencyService.Get<Toast>().Show("Usuario no existe");
			}
			
		}

		private async Task<User> traerUsuario()
		{
			if (string.IsNullOrWhiteSpace(txtRut.Text))
			{
				User user = new User();
				return user;
			}
			else
			{				
				return await usuarioRest.TraeUsuario(txtRut.Text);
			}
		}

		private string BodyMensaje(User user)
		{
			return string.Format("<table style=\"max-width: 600px; padding: 10px; margin:0 auto; border-collapse: collapse;\"><tr>"+
				"<td style=\"padding: 0\"><img style=\"padding: 0; display: block\" src=\"https://i.postimg.cc/Ss3CnPkb/banner-head-correo.png\""+
				" width=\"100%\"></td></tr>	<tr><td style=\"background-color: #ecf0f1\"><div style=\"color: #34495e; margin: 4% 10% 2%; text-align:"+
				" justify;font-family: sans-serif\"><h2 style=\"color: #e67e22; margin: 0 0 7px\">Hola {0}!</h2><p style=\"margin: 2px; font-size: 15px\">"+
				"Según lo solicitado te enviamos tu contreseña: {1} <br>Recuerda que esta contraseña es personal y Disfruta de tu Hora Silenciosa. </p>"+
				"<div style=\"width: 100%;margin:20px 0; display: inline-block;text-align: center\"><img style=\"padding: 0; width: 95%; margin: 5px\""+
				" src=\"https://i.postimg.cc/fWFkhXTp/banner-correo.png\"></div><p style=\"color: #b3b3b3; font-size: 12px; text-align: center;margin: 30px 0 0\">" +
				"Hora Silenciosa by Nicolás Torres</p></div></td></tr></table>",user.nombreCompleto,user.contrasena);
		}
	}
}