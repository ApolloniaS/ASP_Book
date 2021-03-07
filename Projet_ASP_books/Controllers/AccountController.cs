using NetFlask.Models;
using Projet_ASP_books.Infra;
using Projet_ASP_books.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projet_ASP_books.Controllers
{
    public class AccountController : Controller
    {

        UnitOfWork uow = new UnitOfWork(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel lm)
        {
            if (ModelState.IsValid)
            {
                if (lm.Login != "aSorella" && lm.Password != "123477")
                {
                    ViewBag.Error = "Le mot de passe ou le nom d'utilisateur entré est erroné";
                    return View();
                }
                else
                {
                    SessionUtils.IsLogged = true;
                    return RedirectToAction("Index", "Home", new { area = "Member" });
                }
            }
            else
            {
                return View();
            }

        }
        //if (ModelState.IsValid)
        //{
        //    UserModel um = uow.UserAuth(lm);
        //    if (um == null)
        //    {
        //        ViewBag.Error = "Erreur Login/Password";
        //        return View();
        //    }
        //    else
        //    {
        //        SessionUtils.IsLogged = true;
        //        SessionUtils.ConnectedUser = um;
        //        return RedirectToAction("Index", "Home", new { area = "Membre" });
        //    }
        //}
        //else
        //{
        //    return View();
        //}


    }

    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Register(UserModel um)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        if (uow.SignUp(um))
    //        {
    //            SessionUtils.IsLogged = true;
    //            SessionUtils.ConnectedUser = um;
    //            return RedirectToAction("Index", "Home", new { area = "Membre" });
    //        }
    //        else
    //        {
    //            ViewBag.Error = "Erreur Login/Password";
    //            return View("Login");
    //        }
    //    }
    //    else
    //    {
    //        ViewBag.Error = "Erreur Login/Password";
    //        return View("Login");
    //    }
    //}
}
