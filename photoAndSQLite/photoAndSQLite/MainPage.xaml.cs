using System;
using System.Linq;
using Xamarin.Forms;

using Realms;
using System.Collections.ObjectModel;
using System.IO;




namespace photoAndSQLite
{
    public partial class MainPage : ContentPage
    {
// ObservableCollection<string> items = new ObservableCollection<string>();
        ObservableCollection<Item> items = new ObservableCollection<Item>();

        public MainPage()
        {
            InitializeComponent();

            StackLayout layout = new StackLayout();

            Button b = new Button() { Text = "新規データを追加", HorizontalOptions = LayoutOptions.Center };
            b.Clicked += NavButton_Clicked;
            layout.Children.Add(b);
            var realm = Realm.GetInstance();
            var allItems = realm.All<Item>().OrderByDescending((arg) => arg.TimeString);
            foreach (var i in allItems)
            {
                // items.Add(i.TimeString);
                ImageSource source = ImageSource.FromStream(() => new MemoryStream(i.ImageBytes));

                //layout.Children.Add(new Image { Source = source });
                layout.Children.Add(new Label { Text = i.TimeString });

            }
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
            //items.Insert(0, time);
        }
    }
}

