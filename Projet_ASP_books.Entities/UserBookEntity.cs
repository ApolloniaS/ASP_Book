using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_ASP_books.Entities
{
    public class UserBookEntity
    {
        private int _idUserBook, _idUser, _idBook;
       
        private string _title, _login, _readingStatus;

        public int IdUserBook { get => _idUserBook; set => _idUserBook = value; }
        public int IdUser { get => _idUser; set => _idUser = value; }
        public int IdBook { get => _idBook; set => _idBook = value; }
        public string ReadingStatus { get => _readingStatus; set => _readingStatus = value; }
        public string Title { get => _title; set => _title = value; }
        public string Login { get => _login; set => _login = value; }
    }
}
