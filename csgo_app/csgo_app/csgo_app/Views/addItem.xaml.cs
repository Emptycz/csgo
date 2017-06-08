using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using csgo_app.Database;
using SQLite;
using Application = Xamarin.Forms.Application;
using Debug = System.Diagnostics.Debug;
using Plugin.LocalNotifications;

namespace csgo_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class addItem : ContentPage
    {
        private Event event2 = new Event("Název tréninku", "", DateTime.Today, true, "");
        private Event event_edit = new Event(1,"Název tréninku", "", DateTime.Today, true, "", false);

        private int event_ID;
        public addItem(Event event3)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            if (event3.edit == false)
            {
                event2.name = event3.name;
                event2.description = event3.description;
                event2.map = event3.map;
                event2.cas = event3.cas;
                event2.ucast = event3.ucast;

                if (event2.name == "")
                {
                    event2.name = "Nebyl zadán název";
                }

                if (event2.description == "")
                {
                    event2.description = "Nebyl zadán žádný popisek";
                }

                if (event2.map == "")
                {
                    event2.map = "Not selected";
                }

                var dbConnection = App.Database;

                ItemDatabase ItemDatabase = App.Database;
                Item item = new Item();
                item.Cas = event2.cas;
                item.Map = event2.map;
                item.Name = event2.name;
                item.Ucast = event2.ucast;
                item.Description = event2.description;
                App.Database.SaveItemAsync(item);
                if (event2.ucast == true)
                {
                    ShowNotifi(event2.cas);
                }
            }else
            {
                event2.name = event3.name;
                event2.description = event3.description;
                event2.map = event3.map;
                event2.cas = event3.cas;
                event2.ucast = event3.ucast;

                ItemDatabase ItemDatabase = App.Database;
                Item item = new Item();
                App.Database.SaveItemAsync(item);
                item.ID = event2.ID;
                item.Cas = event2.cas;
                item.Map = event2.map;
                item.Name = event2.name;
                item.Ucast = event2.ucast;
                item.Description = event2.description;
            }
        }

        private void ShowNotifi(DateTime date)
        {

            List<Item> itemsFromDb = App.Database.GetLastID().Result;
            foreach (Item i in itemsFromDb)
            {
                int uID = i.ID;
                Debug.WriteLine(date);
                CrossLocalNotifications.Current.Show(event2.name, event2.description, uID, event2.cas);
            }
        }
    
        

        private void RedirectHome_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new csgo_app.MainPage(), false);
        }
    }
}
