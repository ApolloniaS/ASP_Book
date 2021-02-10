using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_ASP_books.Entities
{
    public class CategoryEntity
    {
        private int _idCategory;
        private string _categoryName;

        public int IdCategory { get => _idCategory; set => _idCategory = value; }
        public string CategoryName { get => _categoryName; set => _categoryName = value; }
    }
}
