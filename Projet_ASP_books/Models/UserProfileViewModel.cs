using Projet_ASP_book.Models;
using Projet_ASP_books.Infra;
using Projet_ASP_books.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Projet_ASP_books.Models
{
    public class UserProfileViewModel
    {
        UnitOfWork uow = new UnitOfWork(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);
        private List<ReadingStatusModel> _readingStatus;
        private UserModel _currentUser;
        

        public UserProfileViewModel() {
            //gets the different books read by user (+ status)
            CurrentUser = SessionUtils.ConnectedUser;
            ReadingStatus = uow.GetBooksStatus();
        }

        public List<ReadingStatusModel> ReadingStatus { get => _readingStatus; set => _readingStatus = value; }
        public UserModel CurrentUser { get => _currentUser; set => _currentUser = value; }
    }
}