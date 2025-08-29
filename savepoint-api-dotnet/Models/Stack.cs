using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace savepoint_api_dotnet.Models
{
    [Table("stacks")]
    public class Stack
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Dtc { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // Relationship (many-to-many)
        public List<Game> Games { get; set; }
    }
}