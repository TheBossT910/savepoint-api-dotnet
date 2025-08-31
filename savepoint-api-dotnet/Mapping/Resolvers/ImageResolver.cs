using AutoMapper;
using savepoint_api_dotnet.Data;
using savepoint_api_dotnet.Dtos.Games;
using savepoint_api_dotnet.Models;

namespace savepoint_api_dotnet.Mapping
{
    // For GameUpdateDto
    public class ImageUpdateResolver : IValueResolver<GameUpdateDto, Game, List<Image>>
    {
        private readonly SavePointDbContext _context;
        private readonly IMapper _mapper;

        public ImageUpdateResolver(SavePointDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Image> Resolve(GameUpdateDto source, Game destination, List<Image> destMember, ResolutionContext context)
        {
            var imagesToRemove = destination.Images
                .Where(img => source.Images == null || !source.Images.Any(i => i.Id == img.Id))
                .ToList();

            foreach (var img in imagesToRemove)
            {
                _context.Images.Remove(img);
            }

            return source.Images.Any() ? _mapper.Map<List<Image>>(source.Images) : new List<Image>();
        }
    }
}