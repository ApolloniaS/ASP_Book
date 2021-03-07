using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_ASP_book.Models
{
    public class FullBookInfoModel
    {
        private int _idBook, _nbReviews;
        private string _picture, _title, _summary, _audience, _authorFullName;
        private double _averageScore;
        private DateTime _firstRelease;
        private ReviewModel _review;

        public int IdBook { get => _idBook; set => _idBook = value; }
        public string Picture { get => _picture; set => _picture = value; }
        public string Title { get => _title; set => _title = value; }
        public string Summary { get => _summary; set => _summary = value; }
        public DateTime FirstRelease { get => _firstRelease; set => _firstRelease = value; }
        public string Audience { get => _audience; set => _audience = value; }
        public string AuthorFullName { get => _authorFullName; set => _authorFullName = value; }
        public double AverageScore { get => _averageScore; set => _averageScore = value; }
        public int NbReviews { get => _nbReviews; set => _nbReviews = value; }
        public ReviewModel Review { get => _review; set => _review = value; }
    }
}
