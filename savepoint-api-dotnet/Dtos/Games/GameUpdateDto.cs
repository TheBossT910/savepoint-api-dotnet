using savepoint_api_dotnet.Models;

namespace savepoint_api_dotnet.Dtos.Games
{
    public class GameUpdateDto
    {
        public Guid Id { get; set; }
        public DateTime Dtc { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Cover { get; set; }
        public List<int> DeveloperIds { get; set; }
        public List<int> GenreIds { get; set; }
        public List<int> CategoryIds { get; set; }
        public List<ImageDto> Images { get; set; }
        public List<VideoDto> Videos { get; set; }
        public List<int> GameVariationIds { get; set; }
        // Ignore Stacks and Lists
        public string Splash { get; set; }
        public string Region { get; set; }
        public List<ReviewDto> Reviews { get; set; }
        public PlayTimeDto PlayTime { get; set; }    // NOTE: This is the HLTB data
        public List<int> PlatformIds { get; set; }
    }
}