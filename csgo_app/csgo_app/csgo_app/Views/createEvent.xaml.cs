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
        
        private Event event2 = new Event("", "", DateTime.Today, true, "");

        public createEvent()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

/*            DatePicker datePicker = new DatePicker
            {
                Format = "D",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Changed
            };
            MyLayout.Children.Add(datePicker);*/
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
      

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            if(sender is DatePicker)
            {
                DatePicker datePicker = (DatePicker)sender;
                event2.cas = datePicker.Date;
            }

        }

        private void TimePicker_PropertyChanged(object sender, EventArgs e)
        {
            if (sender is TimePicker)
            {
                TimePicker timePicker = (TimePicker)sender;
                TimeSpan time = timePicker.Time;
                event2.cas = event2.cas + time;
            }
        }

        private void join_Toggled(object sender, ToggledEventArgs e)
        {
            event2.ucast = join.IsToggled;
        }

        private void Continue_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new csgo_app.Views.chooseMap(event2), false);
        }
    }
}
