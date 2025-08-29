using savepoint_api_dotnet.Models;

namespace savepoint_api_dotnet.Dtos.Games
{
    public class GameDto
    {
        public Guid Id { get; set; }
        public DateTime Dtc { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Cover { get; set; }
        public List<DeveloperDto> Developers { get; set; }
        public List<GenreDto> Genres { get; set; }
        public List<ImageDto> Images { get; set; }
        public List<VideoDto> Videos { get; set; }
        public List<GameVariationDto> GameVariations { get; set; }
    }
}