namespace BookStoreApplication.Models
{
    public class Book
    {
        public int Id {  get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        //public List<Description> Descriptions { get; set; }
    }
}
