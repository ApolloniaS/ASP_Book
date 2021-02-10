using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_ASP_books.Entities
{
    public class PublisherBookEntity
    {
        private int _idPublisherBook, _idBook, _idPublisher;
        private DateTime _publicationDate;
        private string _isbn, _linkBuy;
        private double _price;

        public int IdPublisherBook { get => _idPublisherBook; set => _idPublisherBook = value; }
        public int IdBook { get => _idBook; set => _idBook = value; }
        public int IdPublisher { get => _idPublisher; set => _idPublisher = value; }
        public DateTime PublicationDate { get => _publicationDate; set => _publicationDate = value; }
        public string Isbn { get => _isbn; set => _isbn = value; }
        public string LinkBuy { get => _linkBuy; set => _linkBuy = value; }
        public double Price { get => _price; set => _price = value; }
    }
}
