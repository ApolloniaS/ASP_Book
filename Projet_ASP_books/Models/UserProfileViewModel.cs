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
        private UserModel _userInfoModel;
        private List<ReadingStatusModel> _readingStatus;

        public UserProfileViewModel() { 
            //gets the different books read by user (+ status)
            ReadingStatus = uow.GetBooksStatus(SessionUtils.ConnectedUser.IdUser);
        }

        public UserModel UserInfoModel { get => _userInfoModel; set => _userInfoModel = value; }
        public List<ReadingStatusModel> ReadingStatus { get => _readingStatus; set => _readingStatus = value; }
    }
}