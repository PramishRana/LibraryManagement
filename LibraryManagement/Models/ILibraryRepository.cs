using Microsoft.EntityFrameworkCore;    
namespace LibraryManagement.Models
{
    public interface ILibraryRepository
    {
        IEnumerable<Book> AllBooks { get; }
        void AddBook(Book book);
        Book? GetBookById(int BookId);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
        void DeleteBook(int id);
        string? GetrBookById(int id);
    }
}
