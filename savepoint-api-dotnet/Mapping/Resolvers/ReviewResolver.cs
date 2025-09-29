using AutoMapper;
using savepoint_api_dotnet.Data;
using savepoint_api_dotnet.Dtos.Games;
using savepoint_api_dotnet.Models;

namespace savepoint_api_dotnet.Mapping
{
    // For GameUpdateDto
    public class ReviewUpdateResolver : IValueResolver<GameUpdateDto, Game, List<Review>>
    {
        private readonly SavePointDbContext _context;
        private readonly IMapper _mapper;

        public ReviewUpdateResolver(SavePointDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Review> Resolve(GameUpdateDto source, Game destination, List<Review> destMember, ResolutionContext context)
        {
            var reviewsToRemove = destination.Reviews
                .Where(review => source.Reviews == null || !source.Reviews.Any(r => r.Id == review.Id))
                .ToList();

            foreach (var review in reviewsToRemove)
            {
                _context.Reviews.Remove(review);
            }

            return source.Reviews.Any() ? _mapper.Map<List<Review>>(source.Reviews) : new List<Review>();
        }
    }
}