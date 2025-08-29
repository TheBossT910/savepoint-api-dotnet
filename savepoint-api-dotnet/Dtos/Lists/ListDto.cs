using savepoint_api_dotnet.Dtos.Games;
namespace savepoint_api_dotnet.Dtos.Lists
{
    public class ListDto
    {
        public Guid Id { get; set; }
        public DateTime Dtc { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // Relationship (many-to-many)
        public List<GameDto> Games { get; set; }
    }
}