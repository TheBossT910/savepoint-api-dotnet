using AutoMapper;
using savepoint_api_dotnet.Data;
using savepoint_api_dotnet.Dtos.Games;
using savepoint_api_dotnet.Models;

namespace savepoint_api_dotnet.Mapping
{
    // For GameUpdateDto
    public class VideoUpdateResolver : IValueResolver<GameUpdateDto, Game, List<Video>>
    {
        private readonly SavePointDbContext _context;
        private readonly IMapper _mapper;

        public VideoUpdateResolver(SavePointDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Video> Resolve(GameUpdateDto source, Game destination, List<Video> destMember, ResolutionContext context)
        {
            var videosToRemove = destination.Videos
                .Where(video => source.Videos == null || !source.Videos.Any(v => v.Id == v.Id))
                .ToList();

            foreach (var video in videosToRemove)
            {
                _context.Videos.Remove(video);
            }

            return source.Videos.Any() ? _mapper.Map<List<Video>>(source.Videos) : new List<Video>();
        }
    }
}