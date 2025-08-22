using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace savepoint_api_dotnet.Models
{
    [Table("games")]
    public class Game
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Dtc { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Cover { get; set; }
        public List<Developer> Developers { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Image> Images { get; set; }
        public List<Video> Videos { get; set; }
    }
}

