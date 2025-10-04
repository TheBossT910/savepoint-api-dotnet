using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using savepoint_api_dotnet.Data;
using savepoint_api_dotnet.Models.Api;

namespace savepoint_api_dotnet.Services.Apis
{
    public class GamesIGDBApiService
	{
        private readonly RestClient _restClient;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _baseTokenUrl = "https://id.twitch.tv";
        private readonly string _baseUrl = "https://api.igdb.com/v4";
        
        public GamesIGDBApiService(IConfiguration config)
		{
            _restClient = new RestClient(_baseUrl); // IGDB uses OAuth2
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
                .AddStringBody("fields id,name,summary;", DataFormat.None);

            // Making the request
            var response = await _restClient.ExecuteAsync<List<GameIGDB>>(request);
            if (response.IsSuccessful)
                return response.Data ?? new List<GameIGDB>();

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
