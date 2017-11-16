using System;
using System.Collections.Generic;
using System.Text;

using SQLite;
using photoAndSQLite.Database;

[assembly: Dependency(typeof(SQLService))]

namespace photoAndSQLite.iOS.Database
{
    public class SQLService : ISQLService
    {
        public SQLiteConnection GetConnection()
        {
            var personalPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var libraryPath = System.IO.Path.Combine(personalPath, "..", "Library");
            var path = System.IO.Path.Combine(libraryPath, "MyDatabaseName");
            return new SQLiteConnection(path);
        }
    }
}
