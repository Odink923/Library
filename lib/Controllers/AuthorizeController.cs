using lib.Models;
using lib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lib.Controllers
{
    public class AuthorizeController : Controller
    {
        // GET: Authorize
        private LoginService _loginService = new LoginService();
        // GET: Authorize
        public ActionResult Login(string login, string pass)
        {
            var res = _loginService.Login(login, pass);
            if (res == -1) return View("Error");

            Response.Cookies.Add(new HttpCookie("id") { Expires = DateTime.Now.AddDays(1), Value = res.ToString() });

            return RedirectToAction("Index", "Book");

        }

        public ActionResult Register(User user)
        {
            if (_loginService.Register(user)) return RedirectToAction("Log", "Home");
            return View("Error");
        }

        public ActionResult LogOut()
        {
            Response.Cookies.Add(new HttpCookie("id") { Expires = DateTime.Now.AddDays(-1), Value = "-1" });
            return RedirectToAction("Log", "Home");
        }
    }
}