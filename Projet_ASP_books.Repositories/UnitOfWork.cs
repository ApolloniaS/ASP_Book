
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
        IConcreteRepository<UserBookEntity> _userBookRepo;



        public UnitOfWork(string connectionString)
        {
            _bookRepo = new BookRepository(connectionString);
            _authorRepo = new AuthorRepository(connectionString);
            _reviewRepo = new ReviewRepository(connectionString);
            _userRepo = new UserRepository(connectionString);
            _audienceRepo = new AudienceRepository(connectionString);
            _userBookRepo = new UserBookRepository(connectionString);
        }

        #region Home Page
        // function that shows a random book on the home page
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

        // function looking for the latest reviews written
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
        #endregion

        #region Book Page
        // function displaying all books from DB on the search page
        public List<FullBookModel> GetAllBooks(string sortBy, string userInput, int page)
        {
            return ((BookRepository)_bookRepo).SeparatePages(sortBy, userInput, page).Select
                (b => new FullBookModel
                {
                    Review = new ReviewModel() {
                        ReviewContent = String.Join("\n", ((ReviewRepository)_reviewRepo).GetAllReviewsFromABook(b.IdBook).Select(r => r.ReviewContent)),
                        IdBook = b.IdBook,
                    },
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
        #endregion

        #region Reviews

        List<ReviewModel> showReviewsOfABook() {
            return null;
        }
        
        #endregion

        #region Profile
        // function to show basic info on user profile
        public UserModel GetUserInfo()
        {
            // TODO: adapt to get a user dynamically, rn it's only user with id 2 for testing purpose
            // pass param to function here and then pass sessionUtils as param in view ??

            UserEntity userFromDB = _userRepo.GetOne(2);
            UserModel um = new UserModel();
            um.IdUser = userFromDB.IdUser;
            um.FirstName = userFromDB.Firstname;
            um.LastName = userFromDB.Lastname;
            um.Login = userFromDB.Login;

            return um;
        }

        // function to retrieve the books read by user and their status
        //(where false = to be read, true = already read, null = currently reading)
        public List<ReadingStatusModel> GetBooksStatus()
        {
            return ((UserBookRepository)_userBookRepo).Get().Select
                (rs => new ReadingStatusModel
                {
                    Title = rs.Title,
                    Username = rs.Login,
                    Status = rs.ReadingStatus
                }
                ).ToList();
        }   
        #endregion


        // CONTROLLER LOGIN AREA //

        // new user connexion
        //public bool SignUp(UserModel um)
        //{
        //    UserEntity userEntity = new UserEntity()
        //    {
        //        Firstname = um.FirstName,
        //        Lastname = um.LastName,
        //        Login = um.Login,
        //        Password = um.Password
        //    };

        //    return _userRepo.Insert(userEntity);
        //}


        // existing user connexion
        //public UserModel SignIn(LoginModel lm)
        //{
        //    //TODO
        //}
    }
}
