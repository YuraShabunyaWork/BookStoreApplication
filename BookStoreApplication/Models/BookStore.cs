using Bogus;

namespace BookStoreApplication.Models
{
    public class BookStore
    {
        public List<Book> Books { get; set; }
        public Faker Faker { get; set; }
        public Random Random { get; set; }
        public ConfigBooks ConfigBooks { get; set; }
    }
}
