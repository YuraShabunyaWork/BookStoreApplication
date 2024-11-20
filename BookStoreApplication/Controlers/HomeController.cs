using BookStoreApplication.Models;
using BookStoreApplication.Servises;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApplication.Controlers
{
    public class HomeController : Controller
    {
        List<Book> books;
        BookStore bookStore;
        public HomeController()
        {
            
        }
        public IActionResult Index()
        {
            bookStore = new BookStore("en", 42);
            return View(bookStore.AddBooks(20));
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            bookStore = new BookStore("en", 42);
            var items = bookStore.AddBooks(10);
            return View("Index", items);
        }
    }
}
