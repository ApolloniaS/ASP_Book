using Projet_ASP_books.Infra;
using Projet_ASP_books.Models;
using Projet_ASP_books.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projet_ASP_books.Areas.Member.Controllers
{
    public class EditProfileController : Controller
    {
        // GET: Member/EditProfile
        private string[] imgType = { ".png", ".jpg", ".jpeg" };
        UnitOfWork uow = new UnitOfWork(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);

        public ActionResult Edit()
        {
            return View(SessionUtils.ConnectedUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserModel um, HttpPostedFileBase Avatar)
        {

            //Juste pour démontrer l'upload de photo 
            //1- vérifier que la photo à une taille supérieure à 0 et pas trop lourde <200Mo
            if (Avatar.ContentLength > 0 && Avatar.ContentLength < 20000)
            {
                //2 Vérifier le type
                string extension = Path.GetExtension(Avatar.FileName);
                if (imgType.Contains(extension))
                {
                    //3 vérifier si le dossier de destination existe
                    //D:\Cours\Wad20\NetFlask\images\Users\1
                    string destFolder = Path.Combine(Server.MapPath("~/images/Users"), SessionUtils.ConnectedUser.IdUser.ToString());
                    if (!Directory.Exists(destFolder))
                    {
                        Directory.CreateDirectory(destFolder);
                    }

                    //4 - Upload de l'image
                    Avatar.SaveAs(Path.Combine(destFolder, Avatar.FileName));

                    //5 Mise à jour de l'objet User
                    SessionUtils.ConnectedUser.Avatar = Avatar.FileName;

                   
                        uow.EditProfilePic(SessionUtils.ConnectedUser, SessionUtils.ConnectedUser.IdUser);
                    

                }

            }

            return RedirectToAction("Index", "Home", new { area = "Member" });

        }
    }
}