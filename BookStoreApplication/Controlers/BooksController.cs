using Bogus;
using BookStoreApplication.Interfases;
using BookStoreApplication.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

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
            return View(bookStore.Books.Count == 0 ? mahageBookStore.AddBooks(bookStore, 20, bookStore.ConfigBooks.Likes, bookStore.ConfigBooks.Review) : bookStore.Books);
        }

        // Метод для частичного представления
        [HttpGet]
        public IActionResult LoadBooks()
        {
            return PartialView("_BookListPartial", mahageBookStore.AddBooks(bookStore, 10, bookStore.ConfigBooks.Likes, bookStore.ConfigBooks.Review));
        }

        [HttpGet]
        public IActionResult UpdateConfig(string language, int seed, int likes, double review)
        {
            bookStore.Books.Clear();
            Randomizer.Seed = new Random(seed);
            bookStore.Faker = new Bogus.Faker(mahageBookStore.ConvertToShortLanguage(language));
            bookStore.ConfigBooks.Likes = likes;
            bookStore.ConfigBooks.Review = review;
            var books = bookStore.Books.Count == 0 ? mahageBookStore.AddBooks(bookStore, 20, likes, review) : bookStore.Books;
            return Json(new { success = true, books });
        }
    }
}
