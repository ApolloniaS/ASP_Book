using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_ASP_books.Entities
{
    public class PublisherEntity
    {
        private int _idPublisher;
        private string _name;

        public int IdPublisher { get => _idPublisher; set => _idPublisher = value; }
        public string Name { get => _name; set => _name = value; }
    }
}
