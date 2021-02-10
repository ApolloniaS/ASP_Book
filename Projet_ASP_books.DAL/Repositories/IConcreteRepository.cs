using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_ASP_books.DAL.Repositories
{
    public interface IConcreteRepository<T>
    {
        bool Insert(T toInsert);
        bool Update(T toUpdate);
        bool Delete(T toDelete);
        List<T> Get();

        T GetOne(int PK);
    }
}
