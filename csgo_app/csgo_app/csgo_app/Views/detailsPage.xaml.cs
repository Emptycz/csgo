using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csgo_app.Database;
using csgo_app.Views;
using csgo_app;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace csgo_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class detailsPage : ContentPage
    {
        private string ucast;
        public detailsPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            
        }

        private Item ToDelete = new Item();

        public detailsPage(Item item)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            if (item.Ucast == true)
            {
                ucast = "Notification is active!";
            }
            else
            {
                ucast = "Notification is not active!";
            }
            
            nameL.Text = item.Name;
            mapL.Text = item.Map;
            ucastL.Text = ucast;
            descriptionL.Text = item.Description;
            casL.Text = item.Cas.Day.ToString() + "." + item.Cas.Month.ToString() + "." + item.Cas.Year.ToString() + " " + item.Cas.Hour.ToString() + ":" + item.Cas.Minute.ToString();
            
            ToDelete = item;
        }

        private void DeleteObject_Clicked(object sender, EventArgs e)
        {
            OnAlertYesNoClicked(sender, e);
        }

        async void OnAlertYesNoClicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("", "Do you really want to delete this event?", "Yes", "No");
            if ( answer )
            {
                DeleteMe(ToDelete);
            }

        }

        private void DeleteMe(Item ToDelete)
        {
            App.Database.DeleteItemAsync(ToDelete);
            Navigation.PushAsync(new csgo_app.MainPage(), false);
        }

        private void RedirectHome_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new csgo_app.MainPage(), false);
        }
    }
}
