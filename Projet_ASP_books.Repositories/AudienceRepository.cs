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

        // récup le public depuis le livre
        public AudienceEntity GetAudienceFromBook(int idBook)
        {
            string requete = @"SELECT audienceGroup FROM [Audience] INNER JOIN [Book] ON [Book].idAudience = Audience.idAudience WHERE Book.idBook = " +  idBook;
            return base.GetOne(idBook, requete);
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

        public bool ExistOrNot(AudienceEntity toCheck)
        {
            throw new NotImplementedException();
        }
    }
}
