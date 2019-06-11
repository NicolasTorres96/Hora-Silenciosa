using Hs.Clases;
using Hs.Utilidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Hs.Data
{
    public class DiaHsData:Servicio
    {
		public async Task<List<DiaHSClass>> TraerDiasHs()
		{
			try
			{
				string url_servicio = uri_servidor + "/DiaHs/Traer";
				List<DiaHSClass> ls = new List<DiaHSClass>();

				//Envio solicitud
				var response2 = await cliente.GetAsync(url_servicio);

				//verifico respuesta
				if (response2.IsSuccessStatusCode)
				{
					string contenido2 = await response2.Content.ReadAsStringAsync();
					ls = JsonConvert.DeserializeObject<List<DiaHSClass>>(contenido2);
				}
				return ls;
			}
			catch (Exception ex)
			{
				DependencyService.Get<Toast>().Show(ex.ToString());
				return null;
			}

		}
		public async Task<int> RegistroReflexion(DiaHsUserClass diaReflex,EncabezadoDiaHsClass encabezado)
		{
			try
			{
				int resultado = 0;

				string url_servicio = uri_servidor + "/DiaHs/RegistroReflexion/";
				string url_servicio2 = uri_servidor + "/EncabezadoDia/ActualizaRealizada/";

				StringContent contenido = new StringContent(JsonConvert.SerializeObject(diaReflex), Encoding.UTF8, "application/json");
				StringContent contenido2 = new StringContent(JsonConvert.SerializeObject(encabezado), Encoding.UTF8, "application/json");
				//Envio solicitud
				var response2 = await cliente.PostAsync(url_servicio,contenido);

				//verifico respuesta
				if (response2.IsSuccessStatusCode)
				{
					var response = await cliente.PutAsync(url_servicio2, contenido2);
					if (response.IsSuccessStatusCode)
					{
						resultado = 1;
					}					
				}
				return resultado;
			}
			catch (Exception ex)
			{
				DependencyService.Get<Toast>().Show(ex.ToString());
				return 0;
			}
		}

		public async Task<string> TraerReflexion(string diarut)
		{
			try
			{
				string url_servicio = uri_servidor + "/DiaHs/TraerReflexion/"+ diarut;
				DiaHsUserClass ls = new DiaHsUserClass();

				//Envio solicitud
				var response2 = await cliente.GetAsync(url_servicio);

				//verifico respuesta
				if (response2.IsSuccessStatusCode)
				{
					string contenido2 = await response2.Content.ReadAsStringAsync();
					ls = JsonConvert.DeserializeObject<DiaHsUserClass>(contenido2);					
				}
				return ls.reflexion;
			}
			catch (Exception ex)
			{
				DependencyService.Get<Toast>().Show(ex.ToString());
				return null;
			}
		}

		public async Task<List<EncabezadoDiaHsClass>> TraerEncabezado(string rut)
		{
			try
			{
				string url_servicio = uri_servidor + "/EncabezadoDia/GrabaRelaciones/" + rut;
				List < EncabezadoDiaHsClass> ls = new List<EncabezadoDiaHsClass>();

				//Envio solicitud
				var response2 = await cliente.GetAsync(url_servicio);

				//verifico respuesta
				if (response2.IsSuccessStatusCode)
				{
					string contenido2 = await response2.Content.ReadAsStringAsync();
					ls = JsonConvert.DeserializeObject< List<EncabezadoDiaHsClass>>(contenido2);
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
