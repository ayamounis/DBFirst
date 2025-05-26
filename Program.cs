using DBFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DBFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LibraryDbContext context = new LibraryDbContext();


            // context.Database.log = log => Console.WriteLine(log);
            #region Insert a single object 
            Author author = new Author()
            {
                Name = "Yu",

            };
            context.Authors.Add(author);
            context.SaveChanges();
            #endregion

            #region Insert a list of objects 

            var addbook = new List<Book>()
        {
            new Book { Title = "Black Clover", PublishedYear = 1996, AuthorId = author.Id },
            new Book { Title = "A Clash of Kings", PublishedYear = 1998, AuthorId = author.Id }
        };
            context.Books.AddRange(addbook);
            context.SaveChanges();

            #endregion

            #region  Insert using navigation properties 
            Author authorWithBook = new Author()
            {
                Name = "Agatha Christie",
                Books = new List<Book> { new Book { Title = "Murder on the Orient Express", PublishedYear = 1934 } }
            };
            context.Authors.Add(authorWithBook);
            context.SaveChanges();
            #endregion

            #region Update objects 
            var bookToUpdate = context.Books.FirstOrDefault(b => b.Title == "Harry Potter and the Philosopher's Stone");
            if (bookToUpdate != null)
            {
                bookToUpdate.Title = "Harry Potter and the Sorcerer's Stone";
                context.SaveChanges();
            }
                #endregion

                #region  Use EntityState to manipulate object states
                var member = new Member { FullName = "Mohammed Ali" };
                context.Entry(member).State = EntityState.Added;
                context.SaveChanges();
            #endregion

            #region  Delete a list of objects 
            var booksToDelete = context.Books.Where(b => b.AuthorId == author.Id).ToList();
            context.Books.RemoveRange(booksToDelete);
            context.SaveChanges();
            #endregion

            #region  Try eager loading and lazy loading 
            //Eager Loading
            var authorsWithBooks = context.Authors.Include(a => a.Books).ToList();
            //Lazy Loading
            var firstAuthor = context.Authors.First();
            var lazyBooks = firstAuthor.Books;
            #endregion


            //Bonus
            #region  Use AsNoTracking for read-only 
            //var readOnlyBooks = context.Books.AsNoTracking().ToList();
            #endregion

            #region  Use Attach to update
            //var bookToAttach = new Book { Id = 1, Title = "Updated Harry Potter" };
            //context.Attach(bookToAttach);
            //context.Entry(bookToAttach).Property(b => b.Title).IsModified = true;
            //context.SaveChanges();
            #endregion

            #region  Use stored procedures 
            var booksByAuthor = context.Books.FromSqlRaw("EXEC GetBooksByAuthorId @p0", 1).ToList();
            #endregion





        }
    }
}
