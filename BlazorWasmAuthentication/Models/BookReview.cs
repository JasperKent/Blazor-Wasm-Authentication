namespace BlazorWasmAuthentication.Models
{
    public class BookReview
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public double Rating { get; set; }
    }
}
