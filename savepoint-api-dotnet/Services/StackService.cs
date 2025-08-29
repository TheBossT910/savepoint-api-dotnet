using savepoint_api_dotnet.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using savepoint_api_dotnet.Dtos;

namespace savepoint_api_dotnet.Services
{
    public class StackService
    {
        private readonly SavePointDbContext _context;
        private readonly IMapper _mapper;
        public StackService(SavePointDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Get all stacks
        public List<StackDto> GetStacks()
        {
            var stacks = _context.Stacks
                .Include(g => g.Games)
                .ToList();
            return _mapper.Map<List<StackDto>>(stacks);
        }

        // Get a specific stack via id
        public StackDto GetStackById(Guid id)
        {
            var stack = _context.Stacks
                .Include(g => g.Games)
                .FirstOrDefault(g => g.Id == id);
            if (stack == null)
                throw new Exception($"Stack with id {id} not found");
            return _mapper.Map<StackDto>(stack);
        }
    }
}
