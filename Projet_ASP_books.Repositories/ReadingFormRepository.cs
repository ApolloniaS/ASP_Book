using Projet_ASP_books.DAL.Repositories;
using Projet_ASP_books.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_ASP_books.Repositories
{
    public class ReadingFormRepository : BaseRepository<ReadingFormEntity>, IConcreteRepository<ReadingFormEntity>
    {
        public ReadingFormRepository(string connectionString) : base(connectionString)
        {
        }

        public bool Delete(ReadingFormEntity toDelete)
        {
            throw new NotImplementedException();
        }

        public bool ExistOrNot(ReadingFormEntity toCheck)
        {
            throw new NotImplementedException();
        }

        public List<ReadingFormEntity> Get()
        {
            throw new NotImplementedException();
        }

        public ReadingFormEntity GetOne(int PK)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ReadingFormEntity toInsert)
        {
            throw new NotImplementedException();
        }

        public bool Update(ReadingFormEntity toUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
