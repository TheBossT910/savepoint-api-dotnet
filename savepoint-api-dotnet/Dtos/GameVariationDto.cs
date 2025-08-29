using savepoint_api_dotnet.Models;

namespace savepoint_api_dotnet.Dtos
{
    public class GameVariationDto
    {
        public int Id { get; set; }
        public List<Guid> GameIds { get; set; }
    }
}
