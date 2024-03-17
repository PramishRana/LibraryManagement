using LibraryManagement.Models;

namespace LibraryManagement.ViewModel
{
    public class LibraryListViewModel
    {

        public IEnumerable<Book> Books { get; }

        public LibraryListViewModel(IEnumerable<Book> books)
        {

            Books = books;
        }
    }
}
