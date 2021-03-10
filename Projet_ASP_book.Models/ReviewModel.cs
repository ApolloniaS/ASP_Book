using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_ASP_book.Models
{
    public class ReviewModel
    {

        //review-related
        int _idBook;
        string _userAvatar, _username, _reviewContent;
        double _score;
        DateTime _publishedDate;

        public string UserAvatar { get => _userAvatar; set => _userAvatar = value; }
        public string Username { get => _username; set => _username = value; }
        public string ReviewContent { get => _reviewContent; set => _reviewContent = value; }
        public double Score { get => _score; set => _score = value; }
        public DateTime PublishedDate { get => _publishedDate; set => _publishedDate = value; }
        public int IdBook { get => _idBook; set => _idBook = value; }
    }
}
