using Couchbase.Lite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksSummariesApp.Infrastructure
{
    public class DataBaseManager
    {
        private Database _database;
        public Database GetDatabase()
        {
            if(_database==null)
            {
                var dataBaseConfig = new DatabaseConfiguration
                {
                    Directory=Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"BooksDB")
                };
                _database = new Database("BooksDB", dataBaseConfig);
            }
            return _database;
        }

    }
}
