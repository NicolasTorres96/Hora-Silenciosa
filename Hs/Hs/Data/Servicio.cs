using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Hs.Data
{	
	public abstract class Servicio
	{
		protected HttpClient cliente;
		protected string uri_servidor;

		public Servicio()
		{
			cliente = new HttpClient();
			this.uri_servidor = string.Format("https://ppto-sanantonio.caschile.cl/Servicios-Xamarin");//http://186.64.123.223:8080/Servicios-Xamarin
		}
	}
}
