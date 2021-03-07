using Projet_ASP_books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projet_ASP_books.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeViewModel hm = new HomeViewModel();
            return View(hm);
        }


        public ActionResult Books(string sortBy = "", string userInput = null, int page = 1) 
        {
            ViewBag.sortByTitle = String.IsNullOrEmpty(sortBy) ? "Title" : "";
            ViewBag.sortByAuthor = sortBy == "Author" ? "author_desc" : "";
            ViewBag.sortByPublisher = sortBy == "Publisher" ? "publisher_desc" : "";
            ViewBag.sortByRating = sortBy == "Rating" ? "averageScore_desc" : ""; //à adapter !
            BookViewModel bm = new BookViewModel();
            bm.paginateReviews(sortBy, userInput, page);
            return View(bm);
        }

        public ActionResult Reviews()
        {
            BookViewModel bm = new BookViewModel();
            return View(bm);
        }


    }
}