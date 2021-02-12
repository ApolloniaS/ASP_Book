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
