using Projet_ASP_book.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_ASP_books.Models
{
    public class WriteReviewModel
    {
        private ReviewModel _reviewModel;

        public ReviewModel ReviewModel { get => _reviewModel; set => _reviewModel = value; }
    }
}