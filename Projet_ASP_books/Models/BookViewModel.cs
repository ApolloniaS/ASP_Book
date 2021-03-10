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

        private List<FullBookModel> _bookCards;
        private int _maxBook, _maxPage;
        public BookViewModel()
        {
            //BookCards = uow.GetAllBooks();

        }
        public void paginateReviews(string sortBy = "", string userInput = null, int page = 1)
        {

            BookCards = uow.GetAllBooks(sortBy, userInput, page);
            if (userInput != null)
            {
                MaxBook = BookCards.Count();
                MaxPage = BookCards.Count() / 5;
            }

        }

        public List<FullBookModel> BookCards { get => _bookCards; set => _bookCards = value; }
        public int MaxBook { get => _maxBook; set => _maxBook = value; }
        public int MaxPage { get => _maxPage; set => _maxPage = value; }
    }
}