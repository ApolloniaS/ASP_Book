using Projet_ASP_books.DAL.Repositories;
using Projet_ASP_books.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_ASP_books.Repositories
{
    public class BookRepository : BaseRepository<BookEntity>, IConcreteRepository<BookEntity>
    {
        public BookRepository(string connectionString) : base(connectionString)
        {
        }

        //fct ajoutée: afficher un livre au hasard (en List<> car p-e plus qu'un livre au final ?)
        public List<BookEntity> GetOneRandom()
        {
            string requete = "SELECT * from V_RandomBook";
            return base.Get(requete);
        }
        // fct de récup: reprendre les infos d'un livre àpd de la review
        public BookEntity GetBookInfoFromReview(int idReview)
        {
            string requete = @"SELECT title, picture FROM Book INNER JOIN Review ON Book.idBook = Review.idBook WHERE Review.idReview = " + idReview;
            return base.GetOne(idReview, requete);
        }

        // afficher 5 livres à la fois lors de la recherche
        public List<BookEntity> SeparatePages(string sortBy, string userInput, int page)
        {
            string requete = $@"SELECT * FROM V_BookRating";

            if (!String.IsNullOrEmpty(userInput))
            {
                requete += " WHERE title LIKE '%" + userInput + "%' "; // mettre cette partie aussi dans le switch case ? pour auteur/publisher ? WHERE author.firstname LIKE ... ?
            }
            switch (sortBy)
            {
                case "Title":
                    requete += " ORDER BY Title DESC ";
                    break;
                case "Author":
                   requete += " ORDER BY Author ASC "; //attention ici il faut changer la vue car ne prend pas l'id de l'auteur !!!
                   break;
                case "Publisher":
                   requete += " ORDER BY Publisher "; //idem que pour l'auteur, à changer
                   break;
                case "Rating":
                    requete += " ORDER BY averageScore DESC ";
                    break;
                default:
                    requete += " ORDER BY NEWID()";
                    break;
            }



            int booksShown = 5;
            int nextPage = (page - 1) * 5;
            requete += $@"  OFFSET {nextPage} ROWS 
                                FETCH NEXT {booksShown} ROWS ONLY";
            return base.Get(requete);
        }

        public bool Delete(BookEntity toDelete)
        {
            throw new NotImplementedException();
        }

        public List<BookEntity> Get()
        {
            string requete = "SELECT * FROM V_BookRating LEFT JOIN Audience ON Audience.idAudience = V_BookRating.idAudience";
            return base.Get(requete);
        }

        public BookEntity GetOne(int PK)
        {
            string requete = "SELECT * FROM V_BookRating LEFT JOIN Audience ON Audience.idAudience = V_BookRating.idAudience WHERE idBook = @id";
            return base.GetOne(PK, requete);

        }

        public bool Insert(BookEntity toInsert)
        {
            throw new NotImplementedException();
        }

        public bool Update(BookEntity toUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
