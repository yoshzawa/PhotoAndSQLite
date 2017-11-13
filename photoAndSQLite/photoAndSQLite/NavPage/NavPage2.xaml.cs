using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using photoAndSQLite.NavPage;


namespace photoAndSQLite.NavPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavPage2 : ContentPage
    {

        public NavPage2(ImageSource source):this()
        {
            image.Source = source;
        }
        public NavPage2(Plugin.Media.Abstractions.MediaFile file) : this(ImageSource.FromFile(file.Path))
        {
        }


        public NavPage2()
        {
            InitializeComponent();
        }

        private void backButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync(true);
        }

        private void nextButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync(true);
        }
    }
}