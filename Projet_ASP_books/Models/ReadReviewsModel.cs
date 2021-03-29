using Projet_ASP_book.Models;
using Projet_ASP_books.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Projet_ASP_books.Models
{
    public class ReadReviewsModel
    {
        UnitOfWork uow = new UnitOfWork(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);
        private List<ReviewModel> _reviews;
        public ReadReviewsModel(int idBook)
        {
            
            Reviews = uow.displayReviews(idBook);
            
        }

        public List<ReviewModel> Reviews { get => _reviews; set => _reviews = value; }
    }
}