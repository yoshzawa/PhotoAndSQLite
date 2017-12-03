﻿using System;
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




namespace photoAndSQLite
{
    public partial class MainPage : ContentPage
    {
// ObservableCollection<string> items = new ObservableCollection<string>();
        ObservableCollection<ImageSource> items = new ObservableCollection<ImageSource>();

        public MainPage()
        {
            InitializeComponent();
            var realm = Realm.GetInstance();
            var allItems = realm.All<Item>().OrderByDescending((arg) => arg.TimeString);
            foreach (var i in allItems)
            {
                // items.Add(i.TimeString);
                ImageSource source = ImageSource.FromStream(() => new MemoryStream(i.imageBytes));

                items.Add(source);
                testImage.Source = source;
            }
            listView.ItemsSource = items;
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
            items.Insert(0, time);
        }
    }
}

