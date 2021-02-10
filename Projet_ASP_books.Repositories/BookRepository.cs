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
        public bool Delete(BookEntity toDelete)
        {
            throw new NotImplementedException();
        }

        public List<BookEntity> Get()
        {
            throw new NotImplementedException();
        }

        public BookEntity GetOne(int PK)
        {
            throw new NotImplementedException();
        }

        public List<BookEntity> GetOneRandom()
        {
            string requete = "SELECT * from V_RandomBook";
            return base.Get(requete);
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
