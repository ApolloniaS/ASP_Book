
using Projet_ASP_book.Models;
using Projet_ASP_books.DAL.Repositories;
using Projet_ASP_books.Entities;
using Projet_ASP_books.Models;
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
            //TO DO: get the category as well !
            return ((BookRepository)_bookRepo).SeparatePages(sortBy, userInput, page).Select
                (b => new FullBookModel
                {
                    Review = new ReviewModel() {
                        ReviewContent = String.Join("\n", ((ReviewRepository)_reviewRepo).GetAllReviewsFromABook(b.IdBook).Select(r => r.ReviewContent)),
                        IdBook = b.IdBook,
                        //todo change to a list
                        // + get other info (username, date, score)
                    },
                    IdBook = b.IdBook,
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
        public bool addReview(ReviewModel rm, int idUser, int idBook)
        {
            ReviewEntity re = new ReviewEntity()
            {
                IdBook = idBook, 
                IdUser = idUser,
                ReviewContent = rm.ReviewContent,
                ReviewScore = rm.Score,
                ReviewDate = DateTime.Now,
        };
            return _reviewRepo.Insert(re);
        }

        #endregion

        #region Profile

        public List<ReadingStatusModel> GetBooksStatus()
        {
            return ((UserBookRepository)_userBookRepo).Get().Select
                (rs => new ReadingStatusModel
                {
                    IdUser = rs.IdUser,
                    Title = rs.Title,
                    Username = rs.Login,
                    Status = rs.ReadingStatus
                }
                ).ToList();
        }
        public bool AddReadingStatus(int idBook, int idUser, string readingstatus)
        {
            UserBookEntity ube = new UserBookEntity()
            {
                IdBook = idBook,
                IdUser = idUser,
                ReadingStatus = readingstatus,

            };

            if (_userBookRepo.ExistOrNot(ube))
            {
                return _userBookRepo.Insert(ube);
            }
            else 
            {
                return _userBookRepo.Update(ube);
            }
            
        }

        public bool EditProfileInfo(UserModel um, int idUser)
        {
            UserEntity ue = new UserEntity() 
            {
                IdUser = idUser,
                Firstname = um.FirstName,
                Lastname = um.LastName,
                Login = um.Login,
                Avatar = um.Avatar,
                Email = um.Email,
                Password = um.Password,
                Birthdate = um.Birthdate,
                IsAdmin = um.IsAdmin
            };

            return _userRepo.Update(ue);
        }
        #endregion

        #region Connexion/Registration


        //signing up new user
        public bool SignUp(UserModel um)
        {
            UserEntity userEntity = new UserEntity()
            {
                Firstname = um.FirstName,
                Lastname = um.LastName,
                Login = um.Login,
                Email = um.Email,
                Password = um.Password,
                Avatar = um.Avatar,
                Birthdate = um.Birthdate,
                IsAdmin = um.IsAdmin

            };

            return _userRepo.Insert(userEntity);
        }


        // connecting existing user
        public UserModel SignIn(LoginModel lm)
        {
            UserEntity ue = ((UserRepository)_userRepo).GetFromLogin(lm.Login, lm.Password);
            if (ue == null) return null;
            
            if (ue!= null)
            {
                return new UserModel()
                {
                    IdUser = ue.IdUser,
                    FirstName = ue.Firstname,
                    LastName = ue.Lastname,
                    Login = ue.Login,
                    Avatar = ue.Avatar,
                    Email = ue.Login,
                    //Password = ue.Password,
                    Birthdate = ue.Birthdate,
                    IsAdmin = ue.IsAdmin
                };
            }
            else
            {
                return null;
            }
        } 
        #endregion
    }
}
