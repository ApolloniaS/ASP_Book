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
            return View();
        }
    }
}