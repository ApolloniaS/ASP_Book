﻿using Projet_ASP_book.Models;
using Projet_ASP_books.Infra;
using Projet_ASP_books.Models;
using Projet_ASP_books.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projet_ASP_books.Areas.Member.Controllers
{
    public class HomeController : Controller
    {
        // GET: Member/Home
        UnitOfWork uow = new UnitOfWork(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);

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

        
        public ActionResult WriteReview(int idBook)
        {//TODO: gérer une id nulle ou mauvaise url
            if (!SessionUtils.IsLogged) return RedirectToAction("Login", "Account", new { area = "" });
            else
            {
                WriteReviewModel wrm = new WriteReviewModel(idBook);
                return View(wrm);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitReview(ReviewModel rm, int idBook) {

            if (ModelState.IsValid)
            {
                
                uow.addReview(rm, SessionUtils.ConnectedUser.IdUser, idBook);
                return RedirectToAction("Books", "Home", new { area = "" }); ;

            }
            else
            {
                return View();
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateStatusInProfile(int idBook, int idUser, string readingstatus) {

            uow.AddReadingStatus(idBook, idUser, readingstatus);
            return RedirectToAction("Index", "Home", new { area = "Member" }); ;
        }

        
      
    }
}