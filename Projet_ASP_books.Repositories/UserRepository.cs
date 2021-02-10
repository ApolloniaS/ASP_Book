using Projet_ASP_books.DAL.Repositories;
using Projet_ASP_books.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_ASP_books.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IConcreteRepository<UserEntity>
    {
        public UserRepository(string connectionString) : base(connectionString)
        {
        }

        public bool Delete(UserEntity toDelete)
        {
            throw new NotImplementedException();
        }

        public List<UserEntity> Get()
        {
            throw new NotImplementedException();
        }

        public UserEntity GetOne(int PK)
        {
            throw new NotImplementedException();
        }

        public bool Insert(UserEntity toInsert)
        {
            throw new NotImplementedException();
        }

        public bool Update(UserEntity toUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
