using Bogus;
using BookStoreApplication.Interfases;
using BookStoreApplication.Models;

namespace BookStoreApplication.Repository
{
    public class ManageBookStore : IManageBookStore
    {
        public List<Book> AddBooks(BookStore bookStore, int n, int seed)
        {
            Randomizer randomizer = new Randomizer(seed);
            List<Book> newBooks = new List<Book>();
            for (int i = 0; i < n; i++)
            {
                var word = bookStore.Faker.Lorem.Word();
                Book book = new Book
                {
                    Id = bookStore.Books.Count + 1,
                    ISBN = bookStore.Faker.Random.Replace("###-#-###-#####-#"),
                    Author = bookStore.Faker.Name.FullName(),
                    Title = char.ToUpper(word[0]) + word.Substring(1) + " " + bookStore.Faker.Lorem.Word(),
                    Publisher = bookStore.Faker.Company.CompanyName()
                };
                bookStore.Books.Add(book);
                newBooks.Add(book);
            }
            return newBooks;
        }
    }
}
