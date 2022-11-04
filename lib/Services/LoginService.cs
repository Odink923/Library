using lib.Context;
using lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lib.Services
{
    public class LoginService
    {

        private DataContext bookDb = new DataContext("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyBookDb81;Integrated Security=True;");

        public int Login(string login, string pass)
        {
            var user = bookDb.Users.FirstOrDefault(x => x.Login == login && x.Pass == pass);
            return user == null ? -1 : user.Id;
        }

        public bool Register(User user)
        {
            var count = bookDb.Users.Count(x => x.Login == user.Login);
            if (count > 0) return false;
            bookDb.Users.Add(user);
            bookDb.SaveChanges();
            return true;

        }

        public int CountCards(int ID)
        {
            int resault = 0;
            List<Book> basketTemp = new List<Book>();
            try
            {
                basketTemp = bookDb.Users.First(x => x.Id == ID).Books;
                if (basketTemp.Count != 0)
                {
                    resault = basketTemp.Count;
                }
            }
            catch { }
            return resault;
        }
    }
}