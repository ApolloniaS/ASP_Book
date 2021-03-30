using Projet_ASP_books.DAL.Repositories;
using Projet_ASP_books.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_ASP_books.Repositories
{
    public class PublisherBookRepository : BaseRepository<PublisherBookEntity>, IConcreteRepository<PublisherBookEntity>
    {
        public PublisherBookRepository(string connectionString) : base(connectionString)
        {
        }

        public bool Delete(PublisherBookEntity toDelete)
        {
            throw new NotImplementedException();
        }

        public List<PublisherBookEntity> Get()
        {
            throw new NotImplementedException();
        }

        public PublisherBookEntity GetOne(int PK)
        {
            throw new NotImplementedException();
        }

        public bool Insert(PublisherBookEntity toInsert)
        {
            throw new NotImplementedException();
        }

        public bool Update(PublisherBookEntity toUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
