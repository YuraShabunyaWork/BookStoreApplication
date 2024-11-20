using Bogus;
using BookStoreApplication.Models;

namespace BookStoreApplication.Servises
{
    public class BookStore
    {
        public List<Book> Books { get; } = new List<Book>();
        private readonly string language;
        private readonly int seed;

        public BookStore(string language, int seed)
        {
            this.language = language;
            this.seed = seed;
        }
        public List<Book> AddBooks(int n)
        {
            Randomizer.Seed = new Random(seed);
            Faker faker = new Faker(language);
            List<Book> newBooks = new List<Book>();
            for (int i = 0; i < n; i++)
            {
                var word = faker.Lorem.Word();
                Book book = new Book
                {
                    Id = Books.Count + 1,
                    ISBN = faker.Random.Replace("###-#-###-#####-#"),
                    Author = faker.Name.FullName(),
                    Title = Char.ToUpper(word[0]) + word.Substring(1) + " " + faker.Lorem.Word(),
                    Publisher = faker.Company.CompanyName()
                };
                Books.Add(book);
                newBooks.Add(book);
            }
            return newBooks;
        }
    }
}
