using Projet_ASP_books.DAL.Repositories;
using Projet_ASP_books.Entities;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_ASP_books.Repositories
{
    class AuthorRepository : BaseRepository<AuthorEntity>, IConcreteRepository<AuthorEntity>

    {
        public AuthorRepository(string connectionString) : base(connectionString)
        {
        }

        // fct de récup: auteurs via livre
        public List<AuthorEntity> GetAuthorsFromBook(int idBook)
        {

            string requete = @"SELECT firstname, lastname FROM [Author] INNER JOIN BookAuthor
                            ON Author.idAuthor = BookAuthor.idAuthor
                            WHERE BookAuthor.idBook =" + idBook;
            
            return base.Get(requete);
        }
        public bool Delete(AuthorEntity toDelete)
        {
            throw new System.NotImplementedException();
        }

        public List<AuthorEntity> Get()
        {
            throw new System.NotImplementedException();
        }

        public AuthorEntity GetOne(int PK)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(AuthorEntity toInsert)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(AuthorEntity toUpdate)
        {
            throw new System.NotImplementedException();
        }

        public bool ExistOrNot(AuthorEntity toCheck)
        {
            throw new NotImplementedException();
        }
    }
}
