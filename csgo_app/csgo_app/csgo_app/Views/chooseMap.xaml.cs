using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace csgo_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class chooseMap : ContentPage
    {
        private string map;
        private Event event3 = new Event("", "", DateTime.Today, true, "");
        public chooseMap(Event event2)
        {
            InitializeComponent();
            event3.name = event2.name;
            event3.description = event2.description;
            event3.cas = event2.cas;
            event3.ucast = event2.ucast;
        }

        private void Train_Clicked(object sender, EventArgs e)
        {
            event3.map = Train.Text;
            Navigation.PushAsync(new addItem(event3 as Event));
        }

        private void Nuke_Clicked(object sender, EventArgs e)
        {
            event3.map = Nuke.Text;
            Navigation.PushAsync(new addItem(event3 as Event));
        }

        private void Cache_Clicked(object sender, EventArgs e)
        {
            event3.map = Cache.Text;
            Navigation.PushAsync(new addItem(event3 as Event));
        }

        private void Cobble_Clicked(object sender, EventArgs e)
        {
            event3.map = Cobble.Text;
            Navigation.PushAsync(new addItem(event3 as Event));
        }

        private void Overpass_Clicked(object sender, EventArgs e)
        {
            event3.map = Overpass.Text;
            Navigation.PushAsync(new addItem(event3 as Event));
        }

        private void Mirage_Clicked(object sender, EventArgs e)
        {
            event3.map = Mirage.Text;
            Navigation.PushAsync(new addItem(event3 as Event));
        }
    }
}
