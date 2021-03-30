using Projet_ASP_books.DAL.Repositories;
using Projet_ASP_books.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_ASP_books.Repositories
{
    public class CategoryRepository : BaseRepository<CategoryEntity>, IConcreteRepository<CategoryEntity>
    {
        public CategoryRepository(string connectionString) : base(connectionString)
        {
        }

        public bool Delete(CategoryEntity toDelete)
        {
            throw new NotImplementedException();
        }

        public List<CategoryEntity> Get()
        {
            throw new NotImplementedException();
        }

        public CategoryEntity GetOne(int PK)
        {
            throw new NotImplementedException();
        }

        public bool Insert(CategoryEntity toInsert)
        {
            throw new NotImplementedException();
        }

        public bool Update(CategoryEntity toUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
