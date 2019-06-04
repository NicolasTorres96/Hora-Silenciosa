using Hs.Clases;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hs.Data
{
	public class Usuario : Servicio
	{
		public async Task<User> LoginUsuario(User user)
		{
			User usuario = new User();
			string url_servicio = uri_servidor + "/api/usuarios/" + user.rut+"/"+user.contrasena;
						
			var response = await cliente.GetAsync(url_servicio);

			if (response.IsSuccessStatusCode)
			{
				string usuarioJSON = await response.Content.ReadAsStringAsync();
				usuario = JsonConvert.DeserializeObject<User>(usuarioJSON);
			}

			return usuario;
		}

		public async Task<User> TraeUsuario(string rut)
		{
			
			string url_servicio = uri_servidor + "/api/usuarios/"+rut;
			User usuario = new User();
			
			var response = await cliente.GetAsync(url_servicio);

			if (response.IsSuccessStatusCode)
			{
				string usuarioJSON = await response.Content.ReadAsStringAsync();
				usuario = JsonConvert.DeserializeObject<User>(usuarioJSON);
			}
			return usuario;
		}

		public async Task<Int64> RegistroUsuario(User user)
		{
			Int64 retorno = 0;

			string url_servicio = uri_servidor + "/api/usuarios";

			StringContent contenido = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

			var response = await cliente.PostAsync(url_servicio, contenido).ConfigureAwait(false);

			if (response.IsSuccessStatusCode)
			{
				retorno = 1;
			}

			return retorno;
		}
	}
}
