using Hs.Clases;
using Hs.Utilidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;

namespace Hs.Data
{
    public class ClubBiblicoData : Servicio
    {
		public async Task<List<ClubBiblicoClass>> ListarCB()
		{
			try
			{
				string url_servicio = uri_servidor + "/api/club";
				List<ClubBiblicoClass> ls = new List<ClubBiblicoClass>();

				//Envio solicitud
				var response2 = await cliente.GetAsync(url_servicio).ConfigureAwait(false);

				//verifico respuesta
				if (response2.IsSuccessStatusCode)
				{
					string contenido2 = await response2.Content.ReadAsStringAsync();					
					ls = JsonConvert.DeserializeObject<List<ClubBiblicoClass>>(contenido2);
				}
				return ls;
			}
			catch (Exception ex)
			{
				DependencyService.Get<Toast>().Show(ex.ToString());
				return null;
			}
		}

	}
}
