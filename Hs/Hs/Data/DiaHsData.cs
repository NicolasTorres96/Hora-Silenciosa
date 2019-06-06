using Hs.Clases;
using Hs.Utilidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
		public async Task<DiaHsUserClass> TraerRelacion(string rut,string dia)
		{
			try
			{
				string url_servicio = uri_servidor + "/DiaHs/TraerRelacion/"+rut+"/"+dia;
				DiaHsUserClass ls = new DiaHsUserClass();

				//Envio solicitud
				var response2 = await cliente.GetAsync(url_servicio);

				//verifico respuesta
				if (response2.IsSuccessStatusCode)
				{
					string contenido2 = await response2.Content.ReadAsStringAsync();
					ls = JsonConvert.DeserializeObject<DiaHsUserClass>(contenido2);
				}
				return ls;
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
