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
        private int idBook;
        

        public WriteReviewModel(int id)
        {
            IdBook = id;            
        }

        public ReviewModel ReviewModel { get => _reviewModel; set => _reviewModel = value; }
        public int IdBook { get => idBook; set => idBook = value; }

    }
}