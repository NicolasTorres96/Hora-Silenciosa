using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hs.Clases
{
    public class EncabezadoDiaHsClass
    {
		[JsonProperty("diarut")]
		public string Diarut { get; set; }
		[JsonProperty("dia")]
		public string Dia { get; set; }
		[JsonProperty("rut")]
		public string Rut { get; set; }
		[JsonProperty("cita")]
		public string Cita { get; set; }
		[JsonProperty("realizada")]
		public string Realizada { get; set; }
	}
}
