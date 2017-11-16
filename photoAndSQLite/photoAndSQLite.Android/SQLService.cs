using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using SQLite;
[assembly: Dependency(typeof(SQLService))]
namespace photoAndSQLite.Droid
{
    public class SQLService : ISQLService
    {
        public SQLiteConnection GetConnection()
        {
            var personalPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = System.IO.Path.Combine(personalPath, "MyDatabaseName");
            return new SQLiteConnection(path);
        }
    }
}