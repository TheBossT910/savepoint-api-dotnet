using savepoint_api_dotnet.Data;
using System;
using savepoint_api_dotnet.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using savepoint_api_dotnet.Dtos.Games;

namespace savepoint_api_dotnet.Services
{
    public class GameApiService
	{
        private readonly SavePointDbContext _context;
        private readonly IMapper _mapper;
        // TODO: add RestSharp
        public GameApiService(SavePointDbContext context, IMapper mapper)
		{
			_context = context;
            _mapper = mapper;
		}

		// Add games
        // TODO: implement
		public GameDto AddGame(GameCreateDto gameCreateDto)
		{
            throw new NotImplementedException();
        }

        // Get all games
        // TODO: implement
        public List<GameDto> GetGames()
        {
            throw new NotImplementedException();
        }

        // Get a specific game via id
        // TODO: implement
        public GameDto GetGameById(Guid id)
        {
            throw new NotImplementedException();
        }
	}
}
