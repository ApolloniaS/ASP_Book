﻿using Projet_ASP_book.Models;
using Projet_ASP_books.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Projet_ASP_books.Models
{

    public class HomeViewModel
    {
        UnitOfWork uow = new UnitOfWork(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);
        private List<RandomBookModel> _rndmBookModel;
        private List<RecentReviewModel> _recentReviews;
        private LoginRegisterModel _loginRegister;

        public HomeViewModel()
        {
            // displays the random book
            RndmBookModel = uow.GetRandomBook();

            // shows latest reviews
            RecentReviews = uow.ShowRecentReviews();

        }

        public List<RandomBookModel> RndmBookModel { get => _rndmBookModel; set => _rndmBookModel = value; }
        public List<RecentReviewModel> RecentReviews { get => _recentReviews; set => _recentReviews = value; }
        public LoginRegisterModel LoginRegister { get => _loginRegister; set => _loginRegister = value; }
    }
}