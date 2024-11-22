using BookStoreApplication.Interfases;
using BookStoreApplication.Models;

namespace BookStoreApplication.Repository
{
    public class ManageBookStore : IManageBookStore
    {
        public List<Book> AddBooks(BookStore bookStore, int n, int likes, double reviewsPerBook)
        {
            List<Book> newBooks = new List<Book>();
            for (int i = 0; i < n; i++)
            {
                var word = bookStore.Faker.Random.Words(2);
                string[] wordArray = word.Split(' ');
                Book book = new Book
                {
                    Id = bookStore.Books.Count + 1,
                    ISBN = bookStore.Faker.Random.Replace("###-#-###-#####-#"),
                    Author = bookStore.Faker.Name.FullName(),
                    Title = char.ToUpper(word[0]) + word.Substring(1),
                    Publisher = bookStore.Faker.Company.CompanyName()
                };
                Description descriptions = new Description
                {
                    Likes = bookStore.Random.Next(likes),
                    Images = bookStore.Faker.Image.LoremFlickrUrl(240, 320, matchAllKeywords: true, keywords: wordArray[0].Trim().ToLower()),
                    Reviews = new List<Review>()
                };
                book.Descriptions = descriptions;
                bookStore.Books.Add(book);
                newBooks.Add(book);
            }
            GenerateReviews(bookStore, newBooks, n, reviewsPerBook);
            return newBooks;
        }

        public string ConvertToShortLanguage(string language)
        {
            switch (language)
            {
                case "Germany (DE)": return "de";
                case "Français (FR)": return "fr";
                default: return "en";
            }
        }

        protected void GenerateReviews(BookStore bookStore, List<Book> books, int numBooks, double reviewsPerBook)
        {
            double count = numBooks * reviewsPerBook;
            while (count > 0)
            {
                for (int i = 0; i < books.Count; i++)
                {
                    double randValue = bookStore.Random.NextDouble();
                    if (randValue > 0.5)
                    {
                        books[i].Descriptions.Reviews.Add(new Review
                        {
                            Name = bookStore.Faker.Name.FullName(),
                            Text = bookStore.Faker.Rant.Review("Book " + books[i].Title)
                        });
                        count -= 1;
                    }
                }
            }
        }

    }
}
