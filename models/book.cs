namespace BookCollectionAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int Year { get; set; }
        public string? CoverImageUrl { get; set; }
        public int Rating { get; set; } // Rango de 1 a 5
        public string? Review { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}