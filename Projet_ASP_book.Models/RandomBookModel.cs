using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_ASP_book.Models
{
    public class RandomBookModel
    {

        private string _authorFullName, _title, _summary, _picture;
        private int _idBook;

        public string AuthorFullName { get => _authorFullName; set => _authorFullName = value; }
        public string Title { get => _title; set => _title = value; }
        public string Summary { get => _summary; set => _summary = value; }
        public string Picture { get => _picture; set => _picture = value; }
        public int IdBook { get => _idBook; set => _idBook = value; }
    }
}
