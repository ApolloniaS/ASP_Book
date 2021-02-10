using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_ASP_books.Entities
{
    public class UserEntity
    {
        private int _idUser;
        private string _firstname, _lastname, _email, _login, _password, _avatar;
        private bool _isAdmin;
        private DateTime _birthdate;
        private int _salt;

        public int IdUser { get => _idUser; set => _idUser = value; }
        public string Firstname { get => _firstname; set => _firstname = value; }
        public string Lastname { get => _lastname; set => _lastname = value; }
        public string Email { get => _email; set => _email = value; }
        public string Login { get => _login; set => _login = value; }
        public string Password { get => _password; set => _password = value; }
        public bool IsAdmin { get => _isAdmin; set => _isAdmin = value; }
        public DateTime Birthdate { get => _birthdate; set => _birthdate = value; }
        public int Salt { get => _salt; set => _salt = value; }
        public string Avatar { get => _avatar; set => _avatar = value; }
    }
}
