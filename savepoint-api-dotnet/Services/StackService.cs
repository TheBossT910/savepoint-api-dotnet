using AutoMapper;
using Microsoft.EntityFrameworkCore;
using savepoint_api_dotnet.Data;
using savepoint_api_dotnet.Dtos.Games;
using savepoint_api_dotnet.Dtos.Stacks;
using savepoint_api_dotnet.Models;

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

        // Add stack
        public StackDto AddStack(StackCreateDto stackCreateDto)
        {
            var stack = _mapper.Map<Stack>(stackCreateDto);
            _context.Stacks.Add(stack);
            _context.SaveChanges();
            return _mapper.Map<StackDto>(stack);
        }

        // Get all stacks
        public async Task<List<StackDto>> GetStacksAsync()
        {
            var stacks = await _context.Stacks
                .Include(g => g.Games)
                .ToListAsync();
            return _mapper.Map<List<StackDto>>(stacks);
        }

        // Get a specific stack via id
        public async Task<StackDto> GetStackByIdAsync(Guid id)
        {
            var stack = await _context.Stacks
                .Include(g => g.Games)
                .FirstOrDefaultAsync(g => g.Id == id);
            if (stack == null)
                throw new Exception($"Stack with id {id} not found");
            return _mapper.Map<StackDto>(stack);
        }

        // Update stack
        public async Task UpdateStackAsync(StackUpdateDto stackUpdateDto)
        {
            // We need to include Games for the resolver to properly map
            var stack = await _context.Stacks
                .Include(g => g.Games)
                .FirstOrDefaultAsync(g => g.Id == stackUpdateDto.Id);
            if (stack == null)
                throw new Exception($"Update failed. Stack with id {stackUpdateDto.Id} not found");
            _mapper.Map(stackUpdateDto, stack);
            _context.Stacks.Update(stack);
            await _context.SaveChangesAsync();
        }

        // Delete stack
        public void DeleteStack(Guid id)
        {
            var stack = _context.Stacks.Find(id);
            if (stack == null)
                return;
            _context.Stacks.Remove(stack);
            _context.SaveChanges();
        }
    }
}
