using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace csgo_app
{
    public partial class detailsPage : ContentView
    {
        private string ucast;
        public detailsPage()
        {         
            InitializeComponent();
        }
        public detailsPage(Event event2)
        {
            InitializeComponent();

            if(event2.ucast == true)
            {
                ucast = "Zůčastním se";
            }
            else
            {
                ucast = "Nezůčastním se";
            }
            nameL.Text = event2.name;
            casL.Text = event2.cas.ToString();
            mapL.Text = event2.map;
            ucastL.Text = ucast;


        }

    }
}
