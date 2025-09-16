using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace savepoint_api_dotnet.Models
{
    [Table("playtimes")]
    public class PlayTime
    {
        [Key]
        public int Id { get; set; }
        public string Main { get; set; }
        public string MainPlusSides { get; set; }
        public string Completionist { get; set; }
        public string AllStyles { get; set; }
        // Relationship (one-to-many)
        public Guid GameId { get; set; }
        public Game Game { get; set; }
    }
}
