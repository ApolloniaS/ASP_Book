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

        //retrieve username from Review
        public UserEntity GetUserNameFromReview(int idReview) {
            string requete = @"SELECT [login] FROM [User] INNER JOIN [Review] ON [User].idUser = Review.idUser WHERE Review.idReview =" +  idReview;
            return base.GetOne(idReview, requete);
        }

        // check login
        public UserEntity GetFromLogin(string login, string password)
        {
            //TODO : add the SP to check if the password matches the one in the DB
            string requete = @"EXECUTE [dbo].[SP_CHECKPASSWORD] 
                @login, 
                @password";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("login", login);
            p.Add("password", password);
            return base.Get(requete, p).FirstOrDefault();
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
            string requete = "SELECT * FROM [User] WHERE idUser = @id";
            return base.GetOne(PK, requete);
        }

        public bool Insert(UserEntity toInsert)
        {
            string requete = @"EXECUTE [dbo].[User_Insert]
            @firstname,
            @lastname,
            @email,
            @avatar,
            @login,
            @isAdmin,
            @birthdate,
            @password";
            return base.Insert(toInsert, requete);
        }

        public bool Update(UserEntity toUpdate)
        {
            throw new NotImplementedException();
        }

        public bool ExistOrNot(UserEntity toCheck)
        {
            throw new NotImplementedException();
        }
    }
}
