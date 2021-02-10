using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_ASP_books.Entities
{
    public class AudienceEntity
    {
        private int _idAudience;
        private string audienceGroup;

        public int IdAudience { get => _idAudience; set => _idAudience = value; }
        public string AudienceGroup { get => audienceGroup; set => audienceGroup = value; }
    }
}
