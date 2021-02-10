using Projet_ASP_books.DAL.Repositories;
using Projet_ASP_books.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_ASP_books.Repositories
{
    public class AudienceRepository : BaseRepository<AudienceEntity>, IConcreteRepository<AudienceEntity>
    {
        public AudienceRepository(string connectionString) : base(connectionString)
        {
        }
        public bool Delete(AudienceEntity toDelete)
        {
            throw new NotImplementedException();
        }

        public List<AudienceEntity> Get()
        {
            throw new NotImplementedException();
        }

        public AudienceEntity GetOne(int PK)
        {
            throw new NotImplementedException();
        }

        public bool Insert(AudienceEntity toInsert)
        {
            throw new NotImplementedException();
        }

        public bool Update(AudienceEntity toUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
