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

        public UserBookEntity GetFromIds(int idBook, int idUser)
        {
            string requete = @"EXEC [dbo].[SP_Add_Reading_Status] 
                               @idBook
                              ,@idUser";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("idBook", idBook);
            p.Add("idUser", idUser);
            return base.Get(requete, p).FirstOrDefault();
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
            string requete = @"INSERT INTO[dbo].[UserBook] ([idUser], [idBook], [readingStatus]) VALUES (@idUser, @idBook, @readingStatus)";
            return base.Insert(toInsert, requete);
        }

        public bool Update(UserBookEntity toUpdate)
        {
            string requete = @"UPDATE [dbo].[UserBook] SET [idUser] = @idUser, [idBook] = @idBook, [readingStatus] = @readingStatus WHERE idBook = @idBook AND idUser = @idUser";
            return base.Update(toUpdate, requete);
        }

 
    }
}
