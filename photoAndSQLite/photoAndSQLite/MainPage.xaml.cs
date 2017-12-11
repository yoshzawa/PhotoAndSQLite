using Realms;
using System;
using System.IO;
using System.Linq;
using Xamarin.Forms;


namespace photoAndSQLite
{
    public partial class MainPage : ContentPage
    {
        /*
                ObservableCollection<Data> items = new ObservableCollection<Data>();
        */
        public MainPage()
        {

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var realm = Realm.GetInstance();
            var allItems = realm.All<Item>().OrderByDescending((arg) => arg.TimeString);

            var layout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Padding = new Thickness(0, 20, 0, 0)
            };

            Button navButton = new Button()
            {
                Text = " 新規データを追加 ",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor=Color.Aquamarine
            };

            navButton.Clicked += NavButton_Clicked;
            layout.Children.Add(navButton);

            ScrollView scr = new ScrollView
            {
                Orientation = ScrollOrientation.Vertical,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            layout.Children.Add(scr);
            StackLayout sLayout = new StackLayout()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            scr.Content = sLayout;

            foreach (var i in allItems)
            {
                var s = new StackLayout
                {
                    HorizontalOptions = LayoutOptions.Center,
                    Orientation = StackOrientation.Vertical
                };
                //                sLayout.Children.Add(s);
                Frame f = new Frame()
                {
                    HasShadow = true,
                    OutlineColor = Color.Aqua
                };
                f.Content = s;

                s.Children.Add(newLabel(i.TimeString));

                byte[] imageBytes = i.imageBytes;
                ImageSource source = ImageSource.FromStream(() => new MemoryStream(imageBytes));

                Image imagePics = new Image
                {
                    Source = source,
                    WidthRequest = 300
                };
                s.Children.Add(imagePics);

                Image imagePics2 = new Image
                {
                    Source = ImageSource.FromFile(i.UrlString),
                    WidthRequest = 300
                };
                //s.Children.Add(imagePics2);

                s.Children.Add(newLabel(i.imageBytes.Length + " bytes"));
                sLayout.Children.Add(f);
            }

            Content = layout;

        }

        private static Label newLabel(string s)
        {
            return new Label { Text = s };
        }

        private void NavButton_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new NavPage1())
            {
                BarBackgroundColor = Color.FromRgba(0.2, 0.6, 0.86, 1),
                BarTextColor = Color.White
            };
        }

    }
}