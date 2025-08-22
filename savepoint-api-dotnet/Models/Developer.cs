using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace savepoint_api_dotnet.Models
{
    [Table("developers")]
    public class Developer
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Country { get; set; }
		// Relationship (many-to-many)
        public List<Game> Games { get; set; }
    }
}
