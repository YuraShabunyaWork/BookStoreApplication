using Bogus;
using BookStoreApplication.Interfases;
using BookStoreApplication.Models;
using BookStoreApplication.Repository;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace BookStoreApplication.Controlers
{
    public class BooksController : Controller
    {
        private readonly BookStoreService bookStoreService;
        private readonly IManageBookStore manageBookStore;

        public BooksController(BookStoreService bookStoreService, IManageBookStore mahageBookStore)
        {
            this.bookStoreService = bookStoreService;
            this.manageBookStore = mahageBookStore;
        }
        public IActionResult Index()
        {
            bookStoreService.InitializeBookStore(42, "en", 5, 4.5);
            var bookStore = bookStoreService.BookStore;
            var books = manageBookStore.AddBooks(bookStore, 20, bookStore.ConfigBooks.Likes, bookStore.ConfigBooks.Review);
            return View(books);
        }

        [HttpGet]
        public IActionResult LoadBooks()
        {
            var bookStore = bookStoreService.BookStore;
            var books = manageBookStore.AddBooks(bookStore, 10, bookStore.ConfigBooks.Likes, bookStore.ConfigBooks.Review);
            return PartialView("_BookListPartial", books);
        }

        [HttpGet]
        public IActionResult UpdateConfig(string language, int seed, int likes, double review)
        {
            bookStoreService.InitializeBookStore(seed, language, likes, review);
            var bookStore = bookStoreService.BookStore;
            var books = manageBookStore.AddBooks(bookStore, 20, likes, review);
            return PartialView("_BookListPartial", books);
        }
    }
}
