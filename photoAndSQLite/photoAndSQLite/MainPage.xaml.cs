using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using photoAndSQLite;
using Realms;
using System.Collections.ObjectModel;
using System.IO;
using Plugin.Media;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;


namespace photoAndSQLite
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Data> items = new ObservableCollection<Data>();

        public MainPage()
        {
            AppCenter.Start("ios=4767b6a1-63b4-4075-bac1-b760a033ab33;" + "uwp={Your UWP App secret here};" +
                   "android={Your Android App secret here}",
                   typeof(Analytics), typeof(Crashes));

            InitializeComponent();


//            ContentPage page = new ContentPage();
            StackLayout layout = new StackLayout();
            layout.Children.Add(new Label { Text = "", FontSize=40});
            Button button = new Button { Text = "データを追加する", HorizontalOptions = LayoutOptions.Center};
            button.Clicked += NavButton_Clicked;
            layout.Children.Add(button);

//            var realm = Realm.GetInstance();
            /*
                        var allItems = realm.All<Item>().OrderByDescending((arg) => arg.TimeString);
                        foreach (var i in allItems)
                        {
                ImageSource source = ImageSource.FromStream(() => new MemoryStream(i.imageBytes));
                layout.Children.Add(new Label { Text = i.TimeString });
                layout.Children.Add(new Image { Source=  source});
                        }
*/
            Content = layout;

        }

        private void NavButton_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new NavPage1())
            {
                BarBackgroundColor = Color.FromRgba(0.2, 0.6, 0.86, 1),
                BarTextColor = Color.White
            };
        }
        void AddAction(object sender, System.EventArgs e)
        {
            var time = DateTime.UtcNow.ToString("HH:mm:ss");

            // RealmにItemオブジェクトを追加する
            var realm = Realm.GetInstance();
            realm.Write(() =>
            {
                realm.Add(new Item { TimeString = time });
            });

            // ListViewの先頭にも時刻を表示させる
            // items.Insert(0, time);
        }



        class Data
        { 
            public String Time { get; set; }
            public ImageSource Icon { get; set; }
        }
    }
}

