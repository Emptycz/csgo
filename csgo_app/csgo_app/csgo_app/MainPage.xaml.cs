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
            var dbConnection = App.Database;

            ItemDatabase ItemDatabase = App.Database;
            Item item = new Item();
            //item.Cas = cas;
            item.Map = map;
            item.Name = name;
          //  item.Ucast = ucast;
            App.Database.SaveItemAsync(item);

            ListView listView = new ListView
            {
                // Source of data items.
                ItemsSource = App.Database.GetItemsAsync().Result,

                // Define template for displaying each item.
                // (Argument of DataTemplate constructor is called for 
                //      each item; it must return a Cell derivative.)
                ItemTemplate = new DataTemplate(() =>
                {

                    if (ucast == true)
                    {
                        ucast_confirm = "Zůčastním se";
                    }
                    else
                    {
                        ucast_confirm = "Nezůčastním se";
                    }

                    // Create views with bindings for displaying each property.
                    Label nameLabel = new Label();
                    nameLabel.FontSize = 16;
                    nameLabel.SetBinding(Label.TextProperty, "Name");

                    Label mapLabel = new Label();
                    mapLabel.FontSize = 12;
                    mapLabel.SetBinding(Label.TextProperty, "Map");

                    Label timeLabel = new Label();
                    timeLabel.FontSize = 12;
                    timeLabel.SetBinding(Label.TextProperty, "Time");

                    Label ucastLabel = new Label();
                    ucastLabel.FontSize = 12;
                    ucastLabel.SetBinding(Label.TextProperty, ucast_confirm);


                    BoxView myBoxView = new BoxView();

                    // Return an assembled ViewCell.
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Horizontal,
                            Children =
                                {

                                    myBoxView,
                                    new StackLayout
                                    {
                                        VerticalOptions = LayoutOptions.Center,
                                        Spacing = 0,
                                        Children =
                                        {
                                            nameLabel,
                                            mapLabel,
                                            timeLabel,
                                            ucastLabel,
                                        }
                                    }
                                }
                        }
                    };
                })
            };



            listView.ItemTapped += (s, e) =>
            {
                Navigation.PushAsync(new detailsPage(e.Item as Event));
            };
        }


    }
}
