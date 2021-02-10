using Projet_ASP_books.DAL.Repositories;
using Projet_ASP_books.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_ASP_books.Repositories
{
    public class ReviewRepository : BaseRepository<ReviewEntity>, IConcreteRepository<ReviewEntity>
    {
        public ReviewRepository(string connectionString) : base(connectionString)
        {
        }

        public bool Delete(ReviewEntity toDelete)
        {
            throw new NotImplementedException();
        }

        public List<ReviewEntity> Get()
        {
            throw new NotImplementedException();
        }

        public ReviewEntity GetOne(int PK)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ReviewEntity toInsert)
        {
            throw new NotImplementedException();
        }

        public bool Update(ReviewEntity toUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
