namespace savepoint_api_dotnet.Models
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        public string Source { get; set; }
        public string Rating { get; set; }
        public string? Comment { get; set; }
        public string Logo { get; set; }
    }
}
