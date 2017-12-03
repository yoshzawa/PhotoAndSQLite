using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;

namespace photoAndSQLite
{
    public class Item : RealmObject
    {
        public string TimeString { get; set; }
        public byte[] imageBytes { get; set; }
        public string UrlString { get; set; }
    }
}
