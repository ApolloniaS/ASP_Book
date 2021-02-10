
using Projet_ASP_book.Models;
using Projet_ASP_books.DAL.Repositories;
using Projet_ASP_books.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_ASP_books.Repositories
{
    public class UnitOfWork
    {
        //déclaration IConcreteRep<Entity> _xxRepo;
        IConcreteRepository<BookEntity> _bookRepo;
        IConcreteRepository<AuthorEntity> _authorRepo;

        public UnitOfWork(string connectionString)
        {
            //instanciation _xxRepo = new XXRepo(connectionString)
            _bookRepo = new BookRepository(connectionString);
            _authorRepo = new AuthorRepository(connectionString);
        }


        public List<RandomBookModel> GetRandomBook()
        {
            return ((BookRepository)_bookRepo).GetOneRandom()
                .Select
                (rndBook =>
                new RandomBookModel()
                {   
                    IdBook = rndBook.IdBook,
                    Title = rndBook.Title,
                    Picture = rndBook.Picture,
                    Summary = rndBook.Summary,
                    AuthorFullName = String.Join(", ", ((AuthorRepository)_authorRepo).GetAuthorsFromBook(rndBook.IdBook).Select(a => a.FirstName + " " + a.LastName)),
                    //auteur ne s'affiche pas ??
                }

                ).ToList();
        }
    }
}
