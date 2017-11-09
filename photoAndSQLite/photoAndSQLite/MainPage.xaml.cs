using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace photoAndSQLite
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void NavButton_Clicked(object sender, EventArgs e)
        {
            new NavigationPage(new NavPage())
            {
                BarBackgroundColor = Color.FromRgba(0.2, 0.6, 0.86, 1),
                BarTextColor = Color.White
            };
        }
    }
}
