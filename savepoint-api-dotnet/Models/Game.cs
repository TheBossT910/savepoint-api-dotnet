using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace savepoint_api_dotnet.Models
{
    [Table("games")]
    public class Game
    {
        [Key]
        public Guid Id { get; set; }
        // TODO: add slug property for URL-friendly names
        public DateTime Dtc { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Cover { get; set; }
        public List<Developer> Developers { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Image> Images { get; set; }
        public List<Video> Videos { get; set; }
        public List<Stack> Stacks { get; set; }
        public List<List> Lists { get; set; }
        public List<Category> Categories { get; set; }
        public List<GameVariation> GameVariations { get; set; }
        public string Splash { get; set; }
        public string Region { get; set; }
        public List<Review> Reviews { get; set; }
        public PlayTime PlayTime { get; set; }    // NOTE: This is the HLTB data
        public List<Platform> Platforms { get; set; }

        // TODO: add this property. It will be used to mark games that are not running natively
        // This could mean ex. Proton, backwards compatability, etc.
        //public List<int> NonNativePlatformIds { get; set; }
    }
}

