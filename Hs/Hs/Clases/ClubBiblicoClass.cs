using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hs.Clases
{
    public class ClubBiblicoClass
    {
		[JsonProperty("_id")]
		private int _id;
		[JsonProperty("_descripcion")]
		private string _descripcion;

		public int Id { get => _id; set => _id = value; }
		public string Descripcion { get => _descripcion; set => _descripcion = value; }
	}
}
