using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace savepoint_api_dotnet.Models
{
    [Table("videos")]
    public class Video
	{
		[Key]
		public int Id { get; set; }
		public string Url { get; set; }
		public string Source { get; set; }
        // Relationship (one-to-many)
        public Guid GameId { get; set; }
        public Game Game { get; set; }
    }
}
