using Bogus;
using BookStoreApplication.Models;

namespace BookStoreApplication.Repository
{
    public class BookStoreService
    {
        public BookStore BookStore { get; private set; }
        public void InitializeBookStore(int seed, string language, int likes, double review)
        {
            var random = new Random(seed);
            Randomizer.Seed = random;

            BookStore = new BookStore
            {
                Random = random,
                Faker = new Faker(ConvertToShortLanguage(language)),
                ConfigBooks = new ConfigBooks { Likes = likes, Review = review },
                Books = new List<Book>()
            };
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
    }
}
