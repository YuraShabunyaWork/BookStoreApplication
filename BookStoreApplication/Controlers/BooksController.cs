using BookStoreApplication.Interfases;
using BookStoreApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApplication.Controlers
{
    public class BooksController : Controller
    {
        private BookStore bookStore;
        private readonly IManageBookStore mahageBookStore;

        public BooksController(BookStore bookStore, IManageBookStore mahageBookStore)
        {
            if (bookStore == null)
            {
                bookStore = new BookStore() { Books = new List<Book>(), Faker = new Bogus.Faker("en")};
            }
            
            this.bookStore = bookStore;
            this.mahageBookStore = mahageBookStore;
        }

        public ActionResult Index()
        {
            bookStore.Books.Clear();
            return View(mahageBookStore.AddBooks(bookStore, 20, 42));
        }

        // Метод для частичного представления
        [HttpGet]
        public ActionResult LoadBooks()
        {
            return PartialView("_BookListPartial", mahageBookStore.AddBooks(bookStore, 10, 42));
        }
    }
}
