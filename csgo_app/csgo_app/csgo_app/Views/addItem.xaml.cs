using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using csgo_app.Database;
using SQLite;

namespace csgo_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class addItem : ContentPage
    {
        private Event event2 = new Event("", "", /*DateTime.Today,*/ true, "");
        public addItem(Event event3)
        {
            InitializeComponent();
            event2.name = event3.name;
            event2.description = event3.description;
            event2.map = event3.map;
          //  event2.cas = event3.cas;
            event2.ucast = event3.ucast;

            var dbConnection = App.Database;

            ItemDatabase ItemDatabase = App.Database;
            Item item = new Item();
           // item.Cas = event2.cas;
            item.Map = event2.map;
            item.Name = event2.name;
            item.Ucast = event2.ucast;
            App.Database.SaveItemAsync(item);

            Navigation.PushAsync(new csgo_app.MainPage(), false);
        }
    }
}
