using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_ASP_book.Models
{
    public class RecentReviewModel
    {
        private string _picture, _title, _username, _reviewContent;
           private double _reviewScore;

        public string Picture { get => _picture; set => _picture = value; }
        public string Title { get => _title; set => _title = value; }
        public string Username { get => _username; set => _username = value; }
        public string ReviewContent { get => _reviewContent; set => _reviewContent = value; }
        public double ReviewScore { get => _reviewScore; set => _reviewScore = value; }
    }
}
