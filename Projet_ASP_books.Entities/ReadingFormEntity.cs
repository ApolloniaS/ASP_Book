using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_ASP_books.Entities
{
    public class ReadingFormEntity
    {
        private int _idReadingForm, _idUser;
        private string _question, _answer;

        public int IdReadingForm { get => _idReadingForm; set => _idReadingForm = value; }
        public int IdUser { get => _idUser; set => _idUser = value; }
        public string Question { get => _question; set => _question = value; }
        public string Answer { get => _answer; set => _answer = value; }
    }
}
