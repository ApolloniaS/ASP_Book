
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

        public UnitOfWork(string connectionString)
        {
            _bookRepo = new BookRepository(connectionString);
            _authorRepo = new AuthorRepository(connectionString);
            _reviewRepo = new ReviewRepository(connectionString);
            _userRepo = new UserRepository(connectionString);
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
                    AuthorFullName = String.Join(", ", ((AuthorRepository)_authorRepo).GetAuthorsFromBook(rndBook.IdBook).Select(a => a.FirstName + " " + a.LastName)),
                    //auteur ne s'affiche pas ??
                }

                ).ToList();
        }

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
    }
}
