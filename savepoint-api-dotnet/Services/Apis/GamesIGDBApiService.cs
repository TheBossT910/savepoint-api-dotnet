using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using savepoint_api_dotnet.Data;
using savepoint_api_dotnet.Dtos.Games;
using savepoint_api_dotnet.Models;
using savepoint_api_dotnet.Models.Api;

namespace savepoint_api_dotnet.Services.Apis
{
    public class GamesIGDBApiService
	{
        private readonly RestClient _restClient;
        private readonly IMapper _mapper;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _baseTokenUrl = "https://id.twitch.tv";
        private readonly string _baseUrl = "https://api.igdb.com/v4";

        private readonly string _gameRequestFields = "fields aggregated_rating, cover.url, first_release_date, name, platforms.websites.url, platforms.platform_family.name, platforms.platform_logo.url, platforms.platform_type.name, platforms.name, screenshots.url, artworks.url, artworks.artwork_type.slug, summary, videos.video_id, websites.url, genres.name, expanded_games.name, expansions.name, ports.name, involved_companies.company.name, involved_companies.company.logo.url, involved_companies.company.websites.url, involved_companies.company.country, involved_companies.developer;";

        public GamesIGDBApiService(IConfiguration config, IMapper mapper)
		{
            _restClient = new RestClient(_baseUrl); // IGDB uses OAuth2
            _mapper = mapper;
            _clientId = config["IGDB:ClientId"] ?? throw new Exception("IGDB Client ID not found in configuration");
            _clientSecret = config["IGDB:ClientSecret"] ?? throw new Exception("IGDB Client Secret not found in configuration");
        }

		// Get games
		public async Task<List<GameIGDB>> GetGames()
		{
            // Getting/setting the auth tokens
            await SetAuthorizationAsync();

            // Creating the request
            var request = new RestRequest("games", Method.Post)
                .AddHeader("Accept", "application/json")
                .AddStringBody(_gameRequestFields, DataFormat.None);

            // Making the request
            var response = await _restClient.ExecuteAsync<List<GameIGDB>>(request);
            if (response.IsSuccessful)
                return response.Data ?? new List<GameIGDB>();
                //return _mapper.Map<List<Game>>(response.Data) ?? new List<Game>();

            throw new Exception($"Could not get games from IGDB. {response.ErrorMessage}");
        }

        // Get game
        public async Task<List<GameIGDB>> GetGame(String slug)
        {
            // Getting/setting the auth tokens
            await SetAuthorizationAsync();

            // Creating the request
            var request = new RestRequest("games", Method.Post)
                .AddHeader("Accept", "application/json")
                .AddStringBody($"{_gameRequestFields} where slug = \"{slug}\";", DataFormat.None);

            // Making the request
            var response = await _restClient.ExecuteAsync<List<GameIGDB>>(request);
            if (response.IsSuccessful)
                return response.Data ?? new List<GameIGDB>();
                //return _mapper.Map<List<Game>>(response.Data) ?? new List<Game>();

            throw new Exception($"Could not get games from IGDB. {response.ErrorMessage}");
        }

        // Get token
        // Courtesy of https://restsharp.dev/docs/usage/example/#authenticator
        private async Task<string> GetTokenAsync()
        {
            // Create a RestClient for the token endpoint
            var tokenClient = new RestClient(_baseTokenUrl);

            // Create a request to get the token
            var request = new RestRequest("oauth2/token", Method.Post)
                .AddParameter("client_id", _clientId)
                .AddParameter("client_secret", _clientSecret)
                .AddParameter("grant_type", "client_credentials");

            // Execute the request and get the token
            var response = await tokenClient.PostAsync<TokenResponse>(request);
            return $"{response!.TokenType} {response!.AccessToken}";
        }

        // Set token
        private async Task SetAuthorizationAsync()
        {
            var token = await GetTokenAsync();

            _restClient.AddDefaultHeader("Authorization", token);
            _restClient.AddDefaultHeader("Client-ID", _clientId);
        }
    }  
}
