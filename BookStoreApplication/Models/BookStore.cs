using Bogus;

namespace BookStoreApplication.Models
{
    public class BookStore
    {
        public List<Book> Books { get; set; }
        public Faker Faker { get; set; }
    }
}
