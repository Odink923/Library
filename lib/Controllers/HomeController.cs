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
    public class HomeController : Controller
    {
    
        private DataContext bookDb = new DataContext("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyBookDb81;Integrated Security=True;");
        // GET: Home
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

        public ActionResult General()
        {
            return View();
        }
        public ActionResult Log()
        {
            return View();
        }
        
        public ActionResult Reg()
        {
            var res = Request.Cookies["id"];
            if (res != null)
            {
                var id = int.Parse(res.Value);
                ViewBag.UserId = id;
            }
            return View(bookDb.Books.ToList());
        }
        

    }
}