using System.ComponentModel.DataAnnotations.Schema;

namespace savepoint_api_dotnet.Models
{
    [Table("games")]
    public class Game
    {
        public Guid Id { get; set; }
        public DateTime Dtc { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Cover { get; set; }
        // TODO: make seperate table for array types, as SQL does not support arrays
        //public List<Developer> Developers { get; set; }
        //public List<Genre> Genres { get; set; }
        //public List<Image> Images { get; set; }
        //public List<Video> DVideos { get; set; }

        //public string Slug { get; set; }
        //public DateTime ReleaseDate { get; set; }
        //public string Upc { get; set; }
        //public float PriceNew { get; set; }
        //public float PriceComplete { get; set; }
        //public float PriceLoose { get; set; }
        //public int PriceLastUpdated { get; set; }
    }
}

