using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Hs.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(ToastIPhone))]
namespace Hs.iOS
{
	public class ToastIPhone : Utilidades.Toast
	{
		public void Show(string mensaje)
		{
			//ToastIOS.Toast.MakeText(mensaje).Show();
		}
	}
}