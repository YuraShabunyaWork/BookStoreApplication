using Bogus;
using BookStoreApplication.Interfases;
using BookStoreApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

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
                bookStore = new BookStore() { Books = new List<Book>(), 
                    Faker = new Bogus.Faker("en")};           
            }

            if (bookStore.Random == null)
            {
                bookStore.Random = new Random(42);
                Randomizer.Seed = bookStore.Random;
                bookStore.ConfigBooks = new ConfigBooks();
                bookStore.ConfigBooks.Likes = 5;
                bookStore.ConfigBooks.Review = 4.5;
            }

            this.bookStore = bookStore;
            this.mahageBookStore = mahageBookStore;
        }
        public IActionResult Index()
        {
            var books = bookStore.Books.Count < 20 ? mahageBookStore.AddBooks(bookStore, 20, bookStore.ConfigBooks.Likes, bookStore.ConfigBooks.Review) : bookStore.Books;
            return View(books);
        }

        [HttpGet]
        public IActionResult LoadBooks()
        {
            Thread.Sleep(1000);
            var books = mahageBookStore.AddBooks(bookStore, 10, bookStore.ConfigBooks.Likes, bookStore.ConfigBooks.Review);
            return PartialView("_BookListPartial", books);
        }

        [HttpGet]
        public IActionResult UpdateConfig(string language, int seed, int likes, double review)
        {
            bookStore.Books = new List<Book>();
            Randomizer.Seed = new Random(seed);
            bookStore.Faker = new Bogus.Faker(mahageBookStore.ConvertToShortLanguage(language));
            bookStore.ConfigBooks.Likes = likes;
            bookStore.ConfigBooks.Review = review;
            var books = bookStore.Books.Count < 20 ? mahageBookStore.AddBooks(bookStore, 20, likes, review) : bookStore.Books;
            return PartialView("_BookListPartial", books);
        }
    }
}
