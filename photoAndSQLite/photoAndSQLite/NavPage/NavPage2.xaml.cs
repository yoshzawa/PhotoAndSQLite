using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using photoAndSQLite.NavPage;
using Realms;
using System.IO;
using Plugin.Media.Abstractions;



namespace photoAndSQLite.NavPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavPage2 : ContentPage
    {
        MediaFile sourceFile = null;

        public NavPage2(MediaFile file) : this()
        {
            image.Source = ImageSource.FromFile(file.Path);
                sourceFile = file;
        }


        public NavPage2()
        {
            InitializeComponent();
        }

        private void backButton_Clicked(object sender, EventArgs e)
        {
            var time = DateTime.UtcNow.ToString("HH:mm:ss");

            // RealmにItemオブジェクトを追加する
            var realm = Realm.GetInstance();
            realm.Write(() =>
            {

                byte[] iBytes = GetByteArrayFromStream(sourceFile.GetStream());
                realm.Add(new Item { TimeString = time ,imageBytes= iBytes });
            });

        }

        public static byte[] GetByteArrayFromStream(Stream sm)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                sm.CopyTo(ms);
                return ms.ToArray();
            }
        }

        private void nextButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync(true);
        }
    }
}