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
			string url_servicio = uri_servidor + "/api/usuarios/" + user.rut+"/"+user.contraseña;
						
			var response = await cliente.GetAsync(uri_servidor).ConfigureAwait(false);

			if (response.IsSuccessStatusCode)
			{
				string usuarioJSON = await response.Content.ReadAsStringAsync();
				usuario = JsonConvert.DeserializeObject<User>(usuarioJSON);
			}

			return usuario;
		}

		public async Task<User> TraePass(string rut)
		{
			
			string url_servicio = uri_servidor + "/api/usuarios/"+rut;
			User usuario = new User();
			
			var response = await cliente.GetAsync(uri_servidor).ConfigureAwait(false);

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
			Dictionary<string, object> parametros = new Dictionary<string, object>();
			parametros.Add("User", user);

			StringContent contenido = new StringContent(JsonConvert.SerializeObject(parametros), Encoding.UTF8, "application/json");
			var p = JsonConvert.SerializeObject(parametros);
			var response = await cliente.PostAsync(uri_servidor, contenido).ConfigureAwait(false);

			if (response.IsSuccessStatusCode)
			{
				string resultado = await response.Content.ReadAsStringAsync();

				JObject json_obj = JsonConvert.DeserializeObject<JObject>(resultado);
				String x = json_obj.Value<String>("d");
				retorno = Convert.ToInt64(x);
			}

			return retorno;
		}
	}
}
