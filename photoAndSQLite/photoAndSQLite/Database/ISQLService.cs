using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

// http://itblogdsi.blog.fc2.com/blog-entry-154.html
// https://developer.xamarin.com/guides/xamarin-forms/application-fundamentals/databases/


namespace photoAndSQLite.Database
{
    public interface ISQLService
    {
        SQLiteConnection GetConnection();

    }
}
