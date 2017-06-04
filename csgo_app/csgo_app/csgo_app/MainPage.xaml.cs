using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csgo_app.Database;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using csgo_app.Views;

namespace csgo_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private static ItemDatabase _database;
        public static ItemDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new ItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("SQLite2.db3"));
                }
                return _database;
            }
        }
      /*  private List<Event> getEvent()
        {
            List<Event> events = new List<Event>();
            events.Add(new Event("Ranní procvička", "Mirage", "17:20", true));
            return events;
        }*/

        private void selectedItemMethod(object sender, ItemTappedEventArgs e)
        {
            // Grab ListView Item as Person object and send it as parameter to constructor of InfoPage
            Navigation.PushAsync(new createEvent());
        }

        //předdefinování proměnných
        private string name;
        private string map;
        private bool ucast;
        private int cas;
        private string ucast_confirm;

        public MainPage()
        {
            InitializeComponent();
            Redirect.Clicked += (s, e) => {
                Navigation.PushAsync(new createEvent(), false);
            };
            var dbConnection = App.Database;

            ItemDatabase ItemDatabase = App.Database;
            Item item = new Item();
            //item.Cas = cas;
            item.Map = map;
            item.Name = name;
          //  item.Ucast = ucast;
            App.Database.SaveItemAsync(item);



            mainList.ItemsSource = App.Database.GetItemsAsync().Result;
            mainList.ItemTapped += (s, e) =>
            {
                Navigation.PushAsync(new detailsPage(e.Item as Event));
            };
        }

       

}
}
