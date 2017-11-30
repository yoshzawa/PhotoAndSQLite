﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace photoAndSQLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class App : Application
    {
        public App()
        {
            AppCenter.LogLevel = LogLevel.Verbose;

            AppCenter.Start("ios=4767b6a1-63b4-4075-bac1-b760a033ab33;" + 
                "uwp={Your UWP App secret here};" +
                "android={Your Android App secret here}",
                typeof(Analytics), typeof(Crashes));

            InitializeComponent();

            MainPage = new photoAndSQLite.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
