using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFlask.Models
{
    public class UserModel
    {
        int _idUser;
        string _firstName, _lastName, _login, _password, _confirmPassword;

        public int IdUser
        {
            get
            {
                return _idUser;
            }

            set
            {
                _idUser = value;
            }
        }
        [Required]
        [MaxLength(50)]
        public string FirstName
        {
            get
            {
                return _firstName;
            }

            set
            {
                _firstName = value;
            }
        }
        [Required]
        [MaxLength(50)]
        public string LastName
        {
            get
            {
                return _lastName;
            }

            set
            {
                _lastName = value;
            }
        }

        [Required]
        [MaxLength(50)]
        public string Login
        {
            get
            {
                return _login;
            }

            set
            {
                _login = value;
            }
        }

        [Required]
        [MaxLength(50)]
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        [Required]
        [MaxLength(50)]
        [Compare("Password", ErrorMessage = "Les mots de passe ne sont pas identiques !")]
        public string ConfirmPassword
        {
            get
            {
                return _confirmPassword;
            }

            set
            {
                _confirmPassword = value;
            }
        }
    }
}
