using Hs.Clases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Hs.Utilidades
{
    public static class Variables_Globales
    {
		public static UsuarioClass Usuario_Actual
		{
			get
			{
				if (Application.Current.Properties.ContainsKey("usuario_actual") && Application.Current.Properties["usuario_actual"] != null)
				{
					return JsonConvert.DeserializeObject<UsuarioClass>(Application.Current.Properties["usuario_actual"].ToString());
				}
				else
				{
					return null;
				}
			}
			 
			set
			{
				if (value == null)
				{
					Application.Current.Properties["usuario_actual"] = null;
				}
				else
				{
					Application.Current.Properties["usuario_actual"] = JsonConvert.SerializeObject(value);
				}
				Application.Current.SavePropertiesAsync();
			}
		}

		public static bool Usuario_Logeado()
		{
			if (Usuario_Actual != null && Usuario_Actual is UsuarioClass)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
