using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace savepoint_api_dotnet.Models
{
    [Table("reviews")]
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
        public string Source { get; set; }
        public string Rating { get; set; }
        public string Comment { get; set; }
        public string Logo { get; set; }
        // Relationship (one-to-many)
        public Guid GameId { get; set; }
        public Game Game { get; set; }
    }
}
