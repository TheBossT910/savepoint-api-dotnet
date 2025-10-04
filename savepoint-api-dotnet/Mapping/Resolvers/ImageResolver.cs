using AutoMapper;
using savepoint_api_dotnet.Data;
using savepoint_api_dotnet.Dtos.Games;
using savepoint_api_dotnet.Models;
using savepoint_api_dotnet.Models.Api;

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

    // For GameIGDB to Game
    public class ImageIGDBResolver : IValueResolver<GameIGDB, Game, List<Image>>
    {
        private readonly SavePointDbContext _context;

        public ImageIGDBResolver(SavePointDbContext context)
        {
            _context = context;
        }
        public List<Image> Resolve(GameIGDB source, Game destination, List<Image> destMember, ResolutionContext context)
        {
            var images = new List<Image>();
            // First, get all of the images from artworks
            if (source.Artworks != null && source.Artworks.Any())
            {
                var artworkImages = source.Artworks
                    .Select(a => new Image
                    {
                        Url = a.Url,
                        Source = "IGDB",
                    })
                    .ToList();
                images.AddRange(artworkImages);
            }

            // Next, add all of the screenshots
            if (source.Images != null && source.Images.Any())
            {
                var screenshotImages = source.Images
                    .Select(s => new Image
                    {
                        Url = s.Url,
                        Source = "IGDB",
                    })
                    .ToList();
                images.AddRange(screenshotImages);
            }

            return images;
        }
    }
}