using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Plugin.Media;
using Plugin.Media.Abstractions;


namespace photoAndSQLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavPage : ContentPage
    {
        public NavPage()
        {
            InitializeComponent();

            // ボタンが押された時の処理は、asyncメソッドの中で実行する必要があるので、
            // XAMLの中にclickedは書けないんじゃないかと思うけどどうなんだろ

            PictureButton1.Clicked += takePicture;

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

            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });

            //or:
            //image.Source = ImageSource.FromFile(file.Path);
            //image.Dispose();
        }
    }
}