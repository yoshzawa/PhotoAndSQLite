using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Plugin.Media;
using Plugin.Media.Abstractions;

using photoAndSQLite.NavPage;


namespace photoAndSQLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavPage1 : ContentPage
    {
        public NavPage1()
        {
            InitializeComponent();

            pictureButton1.Clicked += takePicture;

            // 初期化した時のイメージを指定
            // 指定方法は http://ytabuchi.hatenablog.com/entry/2017/01/16/170000

            image.Source = ImageSource.FromResource("Lottery.image.Icon.png");

        }

        private void MainPageButton_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new MainPage();
        }

        async void takePicture(object sender, EventArgs e)
        // from https://github.com/jamesmontemagno/MediaPlugin
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            StoreCameraMediaOptions cameraOption = new StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            };

            var file = await CrossMedia.Current.TakePhotoAsync(cameraOption);

            if (file == null)
                return;

            await DisplayAlert("File Location", file.Path, "OK");

/*
            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
*/
            //or:
            //image.Source = ImageSource.FromFile(file.Path);
            //image.Dispose();

            // pictureButton1.Text = "再度撮影する";

            await Navigation.PushAsync(new NavPage2(file), true);
            //await Navigation.PushAsync(new NavPage.NavPage2(image.Source), true);
            //await Navigation.PushAsync(new NavPage.NavPage2(file.Path), true);

        }
    }
}