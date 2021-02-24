
using NetFlask.Models;
using Projet_ASP_book.Models;
using Projet_ASP_books.DAL.Repositories;
using Projet_ASP_books.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_ASP_books.Repositories
{
    public class UnitOfWork
    {
        IConcreteRepository<BookEntity> _bookRepo;
        IConcreteRepository<AuthorEntity> _authorRepo;
        IConcreteRepository<ReviewEntity> _reviewRepo;
        IConcreteRepository<UserEntity> _userRepo;
        IConcreteRepository<AudienceEntity> _audienceRepo;


        public UnitOfWork(string connectionString)
        {
            _bookRepo = new BookRepository(connectionString);
            _authorRepo = new AuthorRepository(connectionString);
            _reviewRepo = new ReviewRepository(connectionString);
            _userRepo = new UserRepository(connectionString);
            _audienceRepo = new AudienceRepository(connectionString);
        }

        // function pour reprendre un livre au hasard en page d'accueil
        public List<RandomBookModel> GetRandomBook()
        {
            return ((BookRepository)_bookRepo).GetOneRandom()
                .Select
                (rndBook =>
                new RandomBookModel()
                {
                    IdBook = rndBook.IdBook,
                    Title = rndBook.Title,
                    Picture = rndBook.Picture,
                    Summary = rndBook.Summary,
                    AuthorFullName = String.Join(", ", ((AuthorRepository)_authorRepo).GetAuthorsFromBook(rndBook.IdBook).Select(a => a.FirstName + " " + a.LastName).ToList()),
                }

                ).ToList();
        }

        // function qui cherche les reviews les + récentes à afficher 
        public List<RecentReviewModel> ShowRecentReviews()
        {
            return ((ReviewRepository)_reviewRepo).GetMostRecentReviews().Select
                (reviews =>
                new RecentReviewModel()
                {
                    Picture = ((BookRepository)_bookRepo).GetBookInfoFromReview(reviews.IdReview).Picture,
                    Title = ((BookRepository)_bookRepo).GetBookInfoFromReview(reviews.IdReview).Title,
                    Username = ((UserRepository)_userRepo).GetUserNameFromReview(reviews.IdReview).Login,
                    ReviewContent = reviews.ReviewContent,
                    ReviewScore = reviews.ReviewScore,
                }
                )
                .ToList();
        }

        // function qui sort tous les livres de la DB sur la page recherche
        public List<FullBookInfoModel> GetAllBooks(string sortBy, string userInput, int page)
        {
            return ((BookRepository)_bookRepo).SeparatePages(sortBy, userInput, page).Select
                (b => new FullBookInfoModel
                {
                    Title = b.Title,
                    Summary = b.Summary,
                    Picture = b.Picture,
                    AverageScore = b.AverageScore,
                    Audience = ((AudienceRepository)_audienceRepo).GetAudienceFromBook(b.IdBook).AudienceGroup,
                    AuthorFullName = String.Join(", ", ((AuthorRepository)_authorRepo).GetAuthorsFromBook(b.IdBook).Select(a => a.FirstName + " " + a.LastName).ToList()),
                    NbReviews = ((ReviewRepository)_reviewRepo).GetAllReviewsFromABook(b.IdBook).Count,

                })
                .ToList();
        }

        // FONCTION DU CONTROLLER DE LOGIN //

        // inscription d'un nouvel utilisateur
        public bool SignUp(UserModel um)
        {
            UserEntity userEntity = new UserEntity()
            {
                Firstname = um.FirstName,
                Lastname = um.LastName,
                Login = um.Login,
                Password = um.Password
            };

            return _userRepo.Insert(userEntity);
        }


        // connexion d'un utilisateur existant
        //public UserModel SignIn(LoginModel lm)
        //{
        //    //TODO
        //}
    }
}
