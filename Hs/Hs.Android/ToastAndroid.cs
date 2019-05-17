using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Hs.Droid;
using Xamarin.Forms;

[assembly:Dependency(typeof(ToastAndroid))]
namespace Hs.Droid
{
	public class ToastAndroid : Utilidades.Toast
	{
		public void Show(string mensaje)
		{
			Android.Widget.Toast.MakeText(Android.App.Application.Context, mensaje, ToastLength.Long).Show();
		}
	}
}