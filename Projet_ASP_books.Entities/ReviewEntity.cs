using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_ASP_books.Entities
{
    public class ReviewEntity
    {
        private int _idReview, _idUser, _idBook;
        private DateTime _reviewDate;
        private string _reviewContent;
        private double _reviewScore;

        public int IdReview { get => _idReview; set => _idReview = value; }
        public int IdUser { get => _idUser; set => _idUser = value; }
        public int IdBook { get => _idBook; set => _idBook = value; }
        public DateTime ReviewDate { get => _reviewDate; set => _reviewDate = value; }
        public string ReviewContent { get => _reviewContent; set => _reviewContent = value; }
        public double ReviewScore { get => _reviewScore; set => _reviewScore = value; }
    }
}
