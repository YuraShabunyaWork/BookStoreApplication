using BookStoreApplication.Models;

namespace BookStoreApplication.Interfases
{
    public interface IManageBookStore
    {
        List<Book> AddBooks(BookStore bookStore, int n, int likes, double reviewsPerBook);
    }
}
