using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        public detailsPage(Event item)
        {
            InitializeComponent();
            
           /* if (event2.ucast == true)
            {
                ucast = "Zůčastním se";
            }
            else
            {
                ucast = "Nezůčastním se";
            }
            */
            nameL.Text = item.name;
            mapL.Text = item.map;
            ucastL.Text = ucast;
            


        }
    }
}
