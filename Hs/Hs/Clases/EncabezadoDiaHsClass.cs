using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hs.Clases
{
    public class EncabezadoDiaHsClass
    {
		[JsonProperty("diarut")]
		public string diarut { get; set; }
		[JsonProperty("dia")]
		public string dia { get; set; }
		[JsonProperty("rut")]
		public string rut { get; set; }
		[JsonProperty("cita")]
		public string cita { get; set; }
		[JsonProperty("realizada")]
		public string realizada { get; set; }
	}
}
