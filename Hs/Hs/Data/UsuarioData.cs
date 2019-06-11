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
	public class UsuarioData : Servicio
	{
		public async Task<UsuarioClass> LoginUsuario(UsuarioClass user)
		{
			UsuarioClass usuario = new UsuarioClass();
			string url_servicio = uri_servidor + "/api/usuarios/" + user.rut+"/"+user.contrasena;
						
			var response = await cliente.GetAsync(url_servicio);

			if (response.IsSuccessStatusCode)
			{
				string usuarioJSON = await response.Content.ReadAsStringAsync();
				usuario = JsonConvert.DeserializeObject<UsuarioClass>(usuarioJSON);
			}

			return usuario;
		}

		public async Task<UsuarioClass> TraeUsuario(string rut)
		{
			
			string url_servicio = uri_servidor + "/api/usuarios/"+rut;
			UsuarioClass usuario = new UsuarioClass();
			
			var response = await cliente.GetAsync(url_servicio);

			if (response.IsSuccessStatusCode)
			{
				string usuarioJSON = await response.Content.ReadAsStringAsync();
				usuario = JsonConvert.DeserializeObject<UsuarioClass>(usuarioJSON);
			}
			return usuario;
		}

		public async Task<Int64> RegistroUsuario(UsuarioClass user)
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
