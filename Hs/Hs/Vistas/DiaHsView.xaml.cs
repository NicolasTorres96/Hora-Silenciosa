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
		public DiaHsView(EncabezadoDiaHsClass encabezado)
		{
			InitializeComponent();
			encabezadoGlobal = encabezado;
			CargaPantalla();
		}

		private async void CargaPantalla()
		{
			lblCita.Text = encabezadoGlobal.Cita;
			lblDia.Text = encabezadoGlobal.Dia;
			await CargaComentario();
			await CargaReflexion();
		}

		private async Task CargaReflexion()
		{
			string reflexion = await diaHsRest.TraerReflexion(encabezadoGlobal.Dia + encabezadoGlobal.Rut);

			txtReflexion.Text = reflexion;
		}

		private async Task CargaComentario()
		{
			ls = await diaHsRest.TraerDiasHs();
			foreach (DiaHSClass item in ls)
			{
				if (item.dia == encabezadoGlobal.Dia)
				{
					lblComentario.Text = item.comentario;
				}
			}
		}

		private async void BtnEnviar_Clicked(object sender, EventArgs e)
		{
			int resultado = 0;

			try
			{
				if (txtReflexion.Text.Trim().Length > 0)
				{
					DiaHsUserClass diaReflexion = new DiaHsUserClass
					{
						reflexion = txtReflexion.Text,
						diarut = encabezadoGlobal.Dia + encabezadoGlobal.Rut,
						dia = encabezadoGlobal.Dia,
						rut = encabezadoGlobal.Rut
					};
					UsuarioClass user = new UsuarioClass();

					resultado = await diaHsRest.RegistroReflexion(diaReflexion, encabezadoGlobal);
					if (resultado == 1)
					{
						await Navigation.PopModalAsync();
						DependencyService.Get<Toast>().Show("Registro correcto");
					}
					else
					{
						DependencyService.Get<Toast>().Show("Error en el Registro");
					}
				}
				else
				{
					DependencyService.Get<Toast>().Show("La hs no puede ser vacia");
				}
			}
			catch (Exception ex)
			{
				DependencyService.Get<Toast>().Show("Error en el Registro");
			}
		}


	}
}