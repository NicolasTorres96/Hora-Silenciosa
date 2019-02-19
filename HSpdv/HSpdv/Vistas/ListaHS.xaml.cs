using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HSpdv
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaHS : ContentPage
    {
        public User _user { get; set; }
        public ObservableCollection<string> Items { get; set; }

        public ListaHS( User user)
        {
            InitializeComponent(); 
            BindingContext = user;

            Items = new ObservableCollection<string>
            {
                "Dia 1",
                "Dia 2",
                "Dia 3",
                "Dia 4",
                "Dia 5"
            };
			
			MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("sGFSDGS",e.Item.ToString(),"ok");//this.Navigation.PushModalAsync(new DiaHsView(e.Item.));
        }
    }
}
