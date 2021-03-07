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

        //fct de récup: username via review
        public UserEntity GetUserNameFromReview(int idReview) {
            string requete = @"SELECT [login] FROM [User] INNER JOIN [Review] ON [User].idUser = Review.idUser WHERE Review.idReview =" +  idReview;
            return base.GetOne(idReview, requete);
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
            throw new NotImplementedException();
        }

        public bool Update(UserEntity toUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
