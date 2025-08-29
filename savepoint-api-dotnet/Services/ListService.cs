using AutoMapper;
using Microsoft.EntityFrameworkCore;
using savepoint_api_dotnet.Data;
using savepoint_api_dotnet.Dtos.Games;
using savepoint_api_dotnet.Dtos.Lists;
using savepoint_api_dotnet.Models;

namespace savepoint_api_dotnet.Services
{
    public class ListService
    {
        private readonly SavePointDbContext _context;
        private readonly IMapper _mapper;
        public ListService(SavePointDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Add list
        public ListDto AddList(ListCreateDto listCreateDto)
        {
            var list = _mapper.Map<List>(listCreateDto);
            _context.Lists.Add(list);
            _context.SaveChanges();
            return _mapper.Map<ListDto>(list);
        }

        // Get all lists
        public List<ListDto> GetLists()
        {
            var lists = _context.Lists
                .Include(g => g.Games)
                .ToList();
            return _mapper.Map<List<ListDto>>(lists);
        }

        // Get a specific list via id
        public ListDto GetListById(Guid id)
        {
            var list = _context.Lists
                .Include(l => l.Games)
                .FirstOrDefault(l => l.Id == id);
            if (list == null)
                throw new Exception($"List with id {id} not found");
            return _mapper.Map<ListDto>(list);
        }

        // Update list
        public void UpdateList(ListUpdateDto listUpdateDto)
        {
            // We need to include Games for the resolver to properly map
            var list = _context.Lists
                .Include(l => l.Games)
                .FirstOrDefault(l => l.Id == listUpdateDto.Id);
            if (list == null)
                throw new Exception($"Update failed. List with id {listUpdateDto.Id} not found");
            _mapper.Map(listUpdateDto, list);
            _context.Lists.Update(list);
            _context.SaveChanges();
        }

        // Delete list
        public void DeleteList(Guid id)
        {
            var list = _context.Lists.Find(id);
            if (list == null)
                return;
            _context.Lists.Remove(list);
            _context.SaveChanges();
        }
    }
}
