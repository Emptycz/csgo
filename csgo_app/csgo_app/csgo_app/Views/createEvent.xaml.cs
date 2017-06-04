using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using csgo_app.Views;
using csgo_app;
using csgo_app.Database;

namespace csgo_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class createEvent : ContentPage
    {
        
        private Event event2 = new Event("", "",/* DateTime.Today,*/ true, "");
        private string DescriptionText;
        private string NameText;
        public createEvent()
        {
            InitializeComponent();
        }
        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
        //    NameText = Name.Text;
            event2.name = Name.Text;
        }

        private void Description_TextChanged(object sender, TextChangedEventArgs e)
        {
        //    DescriptionText = Description.Text;
            event2.description = Description.Text;
        }

        private void Continue_Clicked(object sender, EventArgs e)
        {
          //  event2.name = NameText;
          //  event2.description = DescriptionText;
            Navigation.PushAsync(new csgo_app.Views.chooseMap(event2), false);
        }
    }
}
