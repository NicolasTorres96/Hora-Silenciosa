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
			this.uri_servidor = string.Format("192.168.50.66");
		}
	}
}
