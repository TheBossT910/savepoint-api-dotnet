using savepoint_api_dotnet.Models;

namespace savepoint_api_dotnet.Dtos.Lists
{
    public class ListUpdateDto
    {
        public Guid Id { get; set; }
        // TODO: remove DTC and make it auto-generated in the backend
        public DateTime Dtc { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Guid> GameIds { get; set; }
    }
}