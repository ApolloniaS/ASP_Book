using Projet_ASP_books.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_ASP_books.Models
{
    public class LoginRegisterModel
    {
        public LoginModel LoginModel { get; set; }
        public UserModel UserModel { get; set; }
    }
}