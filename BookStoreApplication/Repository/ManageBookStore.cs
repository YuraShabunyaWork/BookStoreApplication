using Bogus;
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
                var word = bookStore.Faker.Lorem.Word();
                Book book = new Book
                {
                    Id = bookStore.Books.Count + 1,
                    ISBN = bookStore.Faker.Random.Replace("###-#-###-#####-#"),
                    Author = bookStore.Faker.Name.FullName(),
                    Title = char.ToUpper(word[0]) + word.Substring(1) + " " + bookStore.Faker.Lorem.Word(),
                    Publisher = bookStore.Faker.Company.CompanyName()
                };

                Description descriptions = new Description { 
                    Likes = bookStore.Faker.Random.Number(likes), 
                    Images = bookStore.Faker.Image.LoremFlickrUrl(keywords: book.Title + ", " + book.Author),
                    Reviews = GenerateReviews(bookStore, n, reviewsPerBook)};
                book.Descriptions = descriptions;
                bookStore.Books.Add(book);
                newBooks.Add(book);
            }
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

        protected List<Review> GenerateReviews(BookStore bookStore, int numBooks, double reviewsPerBook)
        {
            List<Review> reviews = new List<Review>();
            while (reviewsPerBook > 0)
            {
                double randValue = bookStore.Random.NextDouble();
                if (randValue > reviewsPerBook)
                    reviews.Add(new Review { Name = bookStore.Faker.Name.FullName(), Text = bookStore.Faker.Rant.Review("Book") });
                reviewsPerBook -= 1;
            }
            return reviews;
        }
    }
}
