using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace savepoint_api_dotnet.Models
{
    [Table("platforms")]
    public class Platform
    {
        [Key]
        public int Id { get; set; }
        public string? Company { get; set; }     // ex. Nintendo, Sony, Microsoft, etc.
        public string Hardware { get; set; }    // ex. Switch, Switch 2, PS5, Xbox Series X, PC, etc.
        public string? Store { get; set; }  // Epic, Steam, GOG, etc. (if applicable)
        // If a variation is specified, it is assumed (in a game) that the game is only for that variation. Otherwise (null), it is assumed the game is for all variations of that platform.
        public string? HardwareVariation { get; set; }   // ex. Switch OLED, Switch Lite, PS5 Digital Edition, etc.
        public DateOnly? ReleaseDate { get; set; }
        public string PlatformLogo { get; set; }
        public string? CompanyLogo { get; set; }
        public string? Url { get; set; }
        // Relationship (many-to-many)
        public List<Game> Games { get; set; }
    }
}
