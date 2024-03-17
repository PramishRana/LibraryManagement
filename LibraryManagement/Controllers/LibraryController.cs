using LibraryManagement.Models;
using LibraryManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ILibraryRepository _libraryRepository;
        public LibraryController(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult List()
        {
            LibraryListViewModel libraryListViewModels = new LibraryListViewModel(_libraryRepository.AllBooks);
            return View(libraryListViewModels);
        }
        public IActionResult AddBook()
        {
            var viewModels = new AddBookViewModel();
            return View(viewModels);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBook(AddBookViewModel viewModels)
        {
            Book newBook = new Book
            {
                BookId = viewModels.BookId,
                Title = viewModels.Title,
                Description = viewModels.Description,
                Author = viewModels.Author,
                ImageUrl = viewModels.ImageUrl,
            };
            _libraryRepository.AddBook(newBook);
            return View();
        }
        [HttpGet]

        public ActionResult UpdateBook(int id)
        {
            var Book = _libraryRepository.GetBookById(id);
            var updateBookViewModel = new UpdateBookViewModel
            {
                BookId = Book.BookId,
                Title = Book.Title,
                Description = Book.Description,
                Author = Book.Author,
                ImageUrl = Book.ImageUrl,
            };

            return View(updateBookViewModel);
        }
        [HttpPost]

        public ActionResult UpdateBook(AddBookViewModel viewModels)
        {
            Book newBook = new Book
            {
                BookId = viewModels.BookId,
                Title = viewModels.Title,
                Description = viewModels.Description,
                Author = viewModels.Author,
                ImageUrl = viewModels.ImageUrl,
            };
            _libraryRepository.UpdateBook(newBook);
            return RedirectToAction("List");
        }
        public IActionResult DeleteBook(int Id)
        {

            _libraryRepository.DeleteBook(id: Id);

            return RedirectToAction("List");


        }
    }
}
