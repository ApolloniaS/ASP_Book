using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_ASP_books.Entities
{
    public class BookEntity
    {
        private int _idBook, _idAudience;
        // check encodage b64 pour image
        // au moment de l'upload: créer un dossier avec l'id de l'utilisateur (img/avatar/id) pr éviter d'écraser si même nom de fichier // ou renommer l'img
        private string _title, _summary, _picture;
        private DateTime _firstRelease;

        public int IdBook { get => _idBook; set => _idBook = value; }
        public int IdAudience { get => _idAudience; set => _idAudience = value; }
        public string Title { get => _title; set => _title = value; }
        public string Summary { get => _summary; set => _summary = value; }
        public DateTime FirstRelease { get => _firstRelease; set => _firstRelease = value; }
        public string Picture { get => _picture; set => _picture = value; }
    }
}
