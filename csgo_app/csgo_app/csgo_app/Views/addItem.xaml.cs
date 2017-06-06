﻿using System;
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
        private int event_ID;
        public addItem(Event event3)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            event2.name = event3.name;
            event2.description = event3.description;
            event2.map = event3.map;
            event2.cas = event3.cas;
            event2.ucast = event3.ucast;

            var dbConnection = App.Database;

            ItemDatabase ItemDatabase = App.Database;
            Item item = new Item();
            item.Cas = event2.cas;
            item.Map = event2.map;
            item.Name = event2.name;
            item.Ucast = event2.ucast;
            item.Description = event2.description;
            App.Database.SaveItemAsync(item);
            ShowNotifi(event2.cas);
            
        }

        Command ShowNotifi(DateTime date)
        {
            return new Command((() =>
            {
                List<Item> itemsFromDb = App.Database.GetItemsBy().Result;
                int uID = itemsFromDb[0].ID;
                    Debug.WriteLine(date);
                    CrossLocalNotifications.Current.Show(event2.name, event2.description, 101, event2.cas);
 
            }));
        }

        private void RedirectHome_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new csgo_app.MainPage(), false);
        }
    }
}
