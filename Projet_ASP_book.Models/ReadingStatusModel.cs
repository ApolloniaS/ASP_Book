using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_ASP_book.Models
{
    public class ReadingStatusModel
    {
        string _title, _username, _status;
        int _idUser;
  

        public string Title { get => _title; set => _title = value; }
        public string Username { get => _username; set => _username = value; }
        public string Status { get => _status; set => _status = value; }
        public int IdUser { get => _idUser; set => _idUser = value; }
    }
}
