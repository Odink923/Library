using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lib.Models
{
    public class User
    {
        public User()
        {
            Books = new List<Book>();
         
        }
        public int Id { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }
        public string Name { get; set; }
        public virtual List<Book> Books { get; set; }
    }
}