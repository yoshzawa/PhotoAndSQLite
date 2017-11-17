﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using photoAndSQLite.Database;
using SQLite;


namespace photoAndSQLite
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            String createMessage = createDatabase("database.db");
            if(createMessage.Equals("Database created"))
            {
                Person person=new Person()
                {
                    FirstName="東北",
                    LastName="電二朗",

                };
                insertUpdateData(person,"database.db");
            }


        }

        private void NavButton_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new NavPage1())
            {
                BarBackgroundColor = Color.FromRgba(0.2, 0.6, 0.86, 1),
                BarTextColor = Color.White
            };
        }

        private string createDatabase(string path)
        {
            try
            {
                var connection = new SQLiteAsyncConnection(path);
                connection.CreateTableAsync<Person>();
                return "Database created";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }
        private string insertUpdateData(Person data, string path)
        {
            try
            {
                var db = new SQLiteAsyncConnection(path);

                if (db.InsertAsync(data).Result != 0)
                {
                    db.UpdateAsync(data);
                }

                return "Single data file inserted or updated";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }
        private int findNumberRecords(string path)
        {
            try
            {
                var db = new SQLiteAsyncConnection(path);
                // this counts all records in the database, it can be slow depending on the size of the database
                var count = db.ExecuteScalarAsync<int>("SELECT Count(*) FROM Person").Result;

                // for a non-parameterless query
                // var count = db.ExecuteScalar<int>("SELECT Count(*) FROM Person WHERE FirstName="Amy");

                return count;
            }
            catch (SQLiteException ex)
            {
                return -1;
            }
        }
    }
}

