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
        private bool? _readingStatus;
        // false = à lire // true = lu // null = en cours
    }
}
