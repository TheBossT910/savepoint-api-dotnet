using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace savepoint_api_dotnet.Models
{
    [Table("genres")]
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        // Relationship (many-to-many)
        public List<Game> Games { get; set; }
    }
}
