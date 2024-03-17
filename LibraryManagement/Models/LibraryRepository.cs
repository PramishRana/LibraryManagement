using Microsoft.EntityFrameworkCore;
namespace LibraryManagement.Models
{


    public class LibraryRepository : ILibraryRepository
        {
            private readonly LibrarymanagementDbContext _librarymanagementDbContext;
            public LibraryRepository(LibrarymanagementDbContext librarymanagementDbContext)
            {
                _librarymanagementDbContext = librarymanagementDbContext;
            }
            public IEnumerable<Book> AllBooks
            {
                get
                {
                    return _librarymanagementDbContext.Books;
                }
            }
            public void AddBook(Book book)
            {
                _librarymanagementDbContext.Books.Add(book);
                _librarymanagementDbContext.SaveChanges();
            }
            public Book? GetBookById(int Bookid)
            {
                return _librarymanagementDbContext.Books.FirstOrDefault(p => p.BookId == Bookid);
            }
            public void UpdateBook(Book book)
            {
                var existingBook = _librarymanagementDbContext.Books.FirstOrDefault(p => p.BookId == book.BookId);
                if (existingBook == null)
                {
                    throw new Exception("Books not  found");
                }
                existingBook.Title = book.Title;
                existingBook.Description = book.Description;
                existingBook.Author = book.Author;
                existingBook.ImageUrl = book.ImageUrl;

                _librarymanagementDbContext.Entry(existingBook).State = EntityState.Modified;
                _librarymanagementDbContext.SaveChanges();
            }
            public void DeleteBook(int BookId)
            {

                var book = _librarymanagementDbContext.Books.Find(BookId);

                if (book == null)
                {
                    throw new ArgumentException("Books  not found");
                }


                          _librarymanagementDbContext.Books.Remove(book);
                _librarymanagementDbContext.SaveChanges();

            }

        public void DeleteBook(Book book)
        {
            throw new NotImplementedException();
        }

        public string? GetrBookById(int id)
        {
            throw new NotImplementedException();
        }
    }


   
}
