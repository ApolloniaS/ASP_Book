using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_ASP_books.Entities
{
    public class AuthorEntity
    {
        private int _idAuthor;
        private string _firstName, _lastName;

        public int IdAuthor { get => _idAuthor; set => _idAuthor = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
    }
}
