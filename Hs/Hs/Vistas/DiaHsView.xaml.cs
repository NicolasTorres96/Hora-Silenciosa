using Hs.Clases;
using Hs.Data;
using Hs.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hs.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DiaHsView : ContentPage
	{
		private EncabezadoDiaHsClass encabezadoGlobal = new EncabezadoDiaHsClass();
		private DiaHsData diaHsRest = new DiaHsData();
		private UsuarioData usuarioRest = new UsuarioData();
		private List<DiaHSClass> ls = new List<DiaHSClass>();
		public DiaHsView (EncabezadoDiaHsClass encabezado)
		{
			InitializeComponent ();
			encabezadoGlobal = encabezado;
			cargaPantalla();
		}

		private async void cargaPantalla()
		{
			lblCita.Text = encabezadoGlobal.cita;
			lblDia.Text = encabezadoGlobal.dia;
			await cargaComentario();
			await cargaReflexion();
		}

		private async Task cargaReflexion()
		{
			txtReflexion.Text = await diaHsRest.TraerReflexion(encabezadoGlobal.dia+encabezadoGlobal.rut);
		}

		private async Task cargaComentario()
		{
			ls = await diaHsRest.TraerDiasHs();
			foreach (DiaHSClass item in ls)
			{
				if (item.dia == encabezadoGlobal.dia)
				{
					lblComentario.Text = item.comentario;
				}
			}
		}

		private async void BtnEnviar_Clicked(object sender, EventArgs e)
		{
			int resultado = 0;
			DiaHsUserClass diaReflexion = new DiaHsUserClass();
			diaReflexion.reflexion = txtReflexion.Text;
			diaReflexion.diarut = encabezadoGlobal.dia + encabezadoGlobal.rut;
			diaReflexion.dia = encabezadoGlobal.dia;
			diaReflexion.rut = encabezadoGlobal.rut;
			UsuarioClass user = new UsuarioClass();
			
			resultado = await diaHsRest.RegistroReflexion(diaReflexion, encabezadoGlobal);
			if (resultado == 1)
			{				
				await Navigation.PopModalAsync();
				DependencyService.Get<Toast>().Show("Registro correcto");
				return;
			}
			else
			{
				DependencyService.Get<Toast>().Show("Error en el Registro");
				return;
			}
		}

		
	}
}