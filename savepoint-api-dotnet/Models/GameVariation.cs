using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace savepoint_api_dotnet.Models
{
    [Table("game_variations")]
    public class GameVariation
    {
        [Key]
        public int Id { get; set; }
        // Relationship (many-to-many)
        public List<Game> Games { get; set; }
    }
}
