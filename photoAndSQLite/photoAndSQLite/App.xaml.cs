﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace photoAndSQLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class App : Application
    {
        public App()
        {
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
