using lib.Context;
using lib.Models;
using lib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lib.Controllers
{
    public class BookController : Controller
    {
        private LoginService authorizeService = new LoginService();
        private DataContext bookDb = new DataContext("Data Source=SQL8003.site4now.net;Initial Catalog=db_a8eb5b_lib;User Id=db_a8eb5b_lib_admin;Password=oleh2002");
        public ActionResult Index()
        {

            var cookies = Request.Cookies["id"];
            if (cookies != null)
            {
                var id = int.Parse(cookies.Value);
                var user = bookDb.Users.FirstOrDefault(x => x.Id == id);
                if (user != null)
                {
                    ViewBag.UserId = id;
                    return View(user.Books);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        public ActionResult Add(Book book)
        {

            var cookies = Request.Cookies["id"];
            if (cookies != null)
            {
                var id = int.Parse(cookies.Value);
                ViewBag.UserId = id;

                bookDb.Users.First(x => x.Id == id).Books.Add(book);
                bookDb.SaveChanges();
                return View("Index", bookDb.Users.Find(id).Books);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Delete(int bookId)
        {
            var cookies = Request.Cookies["id"];
            if (cookies != null)
            {
                var l = int.Parse(cookies.Value);
                ViewBag.UserId = l;
                List<Book> lol = new List<Book>();
                int id = -1;
                try
                {
                    id = int.Parse(Request.Cookies["id"].Value);
                    var res = bookDb.Books.FirstOrDefault(x => x.Id == bookId);
                    if (res != null) { bookDb.Books.Remove(res); }

                    if (id != -1)
                    {
                        ViewBag.countPhones = authorizeService.CountCards(id);
                    }
                    bookDb.SaveChanges();
                }
                catch { }
                return View("Index", lol);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


    }
}