using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using csgo_app.Views;

namespace csgo_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class createEvent : ContentPage
    {
        private string name;
        private string description;
        private string day;
        private string time;
        private Event event2 = new Event("", "", DateTime.Today, true, "");
        public createEvent()
        {
            InitializeComponent();
        }
        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            event2.name = Name.Text;
        }

        private void Start_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Day_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Description_TextChanged(object sender, TextChangedEventArgs e)
        {
            event2.description = Description.Text;
        }

        private void Continue_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new chooseMap(event2 as Event));
        }
    }
}
