using AutoMapper;
using savepoint_api_dotnet.Data;
using savepoint_api_dotnet.Models;
using savepoint_api_dotnet.Models.Api;

namespace savepoint_api_dotnet.Mapping
{

    // For GameIGDB to Game
    public class SplashIGDBResolver : IValueResolver<GameIGDB, Game, String>
    {
        private readonly SavePointDbContext _context;

        public SplashIGDBResolver(SavePointDbContext context)
        {
            _context = context;
        }
        public String Resolve(GameIGDB source, Game destination, String destMember, ResolutionContext context)
        {
            // Get the splash image from artworks if available
            if (source.Artworks != null && source.Artworks.Any())
            {
                // Try to find artwork with type "artwork" first
                var splashArtwork = source.Artworks.FirstOrDefault(a => a.ArtworkType != null && a.ArtworkType.Slug == "artwork");
                if (splashArtwork != null && !string.IsNullOrEmpty(splashArtwork.Url))
                {
                    return splashArtwork.Url;
                }

                // Fallback to "key-art-with-logo" if "artwork" not found
                splashArtwork = source.Artworks.FirstOrDefault(a => a.ArtworkType != null && a.ArtworkType.Slug == "key-art-with-logo");
                if (splashArtwork != null && !string.IsNullOrEmpty(splashArtwork.Url))
                {
                    return splashArtwork.Url;
                }

                // Fallback to "key-art-with-logo" if "artwork" not found
                splashArtwork = source.Artworks.FirstOrDefault(a => a.ArtworkType != null && a.ArtworkType.Slug == "key-art-without-logo");
                if (splashArtwork != null && !string.IsNullOrEmpty(splashArtwork.Url))
                {
                    return splashArtwork.Url;
                }
            }

            // Fallback to cover image if no suitable artwork found
            return source.Cover.Url;
        }
    }
}