using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HSpdv
{
    public class MyContentPage :ContentPage
    {
        public MyContentPage()
        {
            var label = new Label
            {
                Text = "Escribe tu Nombre"
            };
            var texto = new Entry
            {
                Placeholder = "Escribe tu Nombre"
            };
            var btn = new Button
            {
                Text = "Holi",
                BackgroundColor =Color.Green
            };
            btn.Clicked += (sender, e) =>
            {
                DisplayAlert("Mensaje", "Hola "+ texto.Text, "OK");
            };
            Content = new StackLayout
            {
                Padding = 30,
                Spacing = 10,
                Children = { label, texto ,btn}
                
            };
        }
    }
}
