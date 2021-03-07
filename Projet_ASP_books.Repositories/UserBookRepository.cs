using Projet_ASP_books.DAL.Repositories;
using Projet_ASP_books.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_ASP_books.Repositories
{
    public class UserBookRepository : BaseRepository<UserBookEntity>, IConcreteRepository<UserBookEntity>
    {
        public UserBookRepository(string connectionString) : base(connectionString)
        {
        }

        public bool Delete(UserBookEntity toDelete)
        {
            throw new NotImplementedException();
        }

        public List<UserBookEntity> Get()
        {
            string requete = @"SELECT * FROM V_ReadingStatus";
            return base.Get(requete);
        }

        public UserBookEntity GetOne(int PK)
        {
            throw new NotImplementedException();
        }

        public bool Insert(UserBookEntity toInsert)
        {
            throw new NotImplementedException();
        }

        public bool Update(UserBookEntity toUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
