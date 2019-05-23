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
    public class ClubBiblico : Servicio
    {
		public async Task<List<ClubBiblicoClass>> ListarCB()
		{
			try
			{
				string url_servicio = uri_servidor + "api/clubes";
				List<ClubBiblicoClass> ls = new List<ClubBiblicoClass>();

				//Envio solicitud
				var response2 = await cliente.GetAsync(url_servicio).ConfigureAwait(false);

				//verifico respuesta
				if (response2.IsSuccessStatusCode)
				{
					string contenido2 = await response2.Content.ReadAsStringAsync();
					XElement xml2 = XElement.Parse(contenido2);
					string json2 = xml2.FirstNode.ToString();
					ls = JsonConvert.DeserializeObject<List<ClubBiblicoClass>>(json2);
				}
				return ls;
			}
			catch (Exception ex)
			{
				DependencyService.Get<Toast>().Show(ex.ToString());
				throw;
			}
		}

	}
}
