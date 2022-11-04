using lib.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace lib.Context
{
    public class DataContext: DbContext
    {
        public DataContext(string connectionString): base(connectionString)
        {
            Database.CreateIfNotExists();
        }
        public DbSet <Book> Books { get; set; }
        public DbSet <User> Users { get; set; }

    }
}