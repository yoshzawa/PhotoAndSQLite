using Plugin.Media.Abstractions;
using Realms;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace photoAndSQLite.NavPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavPage2 : ContentPage
    {
        MediaFile sourceFile = null;

        public NavPage2(MediaFile file) : this()
        {
            //image.Source = ImageSource.FromFile(file.Path);
            sourceFile = file;

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            byte[] iBytes = GetByteArrayFromStream(sourceFile.GetStream());
            DisplayAlert("NavPage2", "length" + iBytes.Length, "OK");
            image.Source = ImageSource.FromStream(() => new MemoryStream(iBytes));
        }

        public NavPage2()
        {
            InitializeComponent();
        }

        private void backButton_Clicked(object sender, EventArgs e)
        {

            Navigation.PopAsync(true);

        }

        public static byte[] GetByteArrayFromStream(Stream sm)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                sm.CopyTo(ms);
                return ms.ToArray();
            }
        }
        public byte[] GetImageStreamAsBytes(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }




        private void nextButton_Clicked(object sender, EventArgs e)
        {
            var time = DateTime.UtcNow.ToString("HH:mm:ss");

            // RealmにItemオブジェクトを追加する
            var realm = Realm.GetInstance();
            realm.Write(() =>
            {

                byte[] iBytes = GetByteArrayFromStream(sourceFile.GetStream());
                //byte[] iBytes = GetImageStreamAsBytes(sourceFile.GetStream());
                //byte[] iBytes = image.toByteArray();
                realm.Add(new Item { TimeString = time, imageBytes = iBytes });
                DisplayAlert("NavPage2", "length" + iBytes.Length, "OK");
            });
            // Navigation.PopToRootAsync(true);
            Application.Current.MainPage = new MainPage();

        }
    }
}