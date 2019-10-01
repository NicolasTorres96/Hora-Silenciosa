using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hs.Clases
{
    public class ClubBiblicoClass
    {
		public int id { get; set; }
		public string descripcion { get; set; }

		public ClubBiblicoClass(int id,string descripcion)
		{
			this.id = id;
			this.descripcion = descripcion;
		}
	}
}
