using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace photoAndSQLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavPage : ContentPage
    {
        public NavPage()
        {
            InitializeComponent();
        }

        private void MainPageButton_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new MainPage();
        }
    }
}