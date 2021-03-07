using Projet_ASP_books.Infra;
using Projet_ASP_books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projet_ASP_books.Areas.Member.Controllers
{
    public class HomeController : Controller
    {
        // GET: Member/Home
        public ActionResult Index()
        {
            if (!SessionUtils.IsLogged) return RedirectToAction("Login", "Account", new { area = "" });
            else { 
            UserProfileViewModel upvm = new UserProfileViewModel();
            return View(upvm);
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();

           return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}