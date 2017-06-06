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

        Item ToDelete = new Item();

        public detailsPage(Item item)
        {
            InitializeComponent();
            
            if (item.Ucast == true)
            {
                ucast = "Zůčastním se";
            }
            else
            {
                ucast = "Nezůčastním se";
            }
            
            nameL.Text = item.Name;
            mapL.Text = item.Map;
            ucastL.Text = ucast;
            descriptionL.Text = item.Description;
            casL.Text = item.Cas.ToString();//item.Cas.Day.ToString() + "." + item.Cas.Month.ToString() + "." + item.Cas.Year.ToString();
            

            ToDelete = item;
        }

        private void DeleteObject_Clicked(object sender, EventArgs e)
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
