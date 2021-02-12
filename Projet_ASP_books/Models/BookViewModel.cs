using Projet_ASP_book.Models;
using Projet_ASP_books.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Projet_ASP_books.Models
{
    public class BookViewModel
    {
        UnitOfWork uow = new UnitOfWork(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);

        private List<FullBookInfoModel> _bookCards;
        public BookViewModel()
        {
            BookCards = uow.GetAllBooks();
        }

        public List<FullBookInfoModel> BookCards { get => _bookCards; set => _bookCards = value; }
    }
}