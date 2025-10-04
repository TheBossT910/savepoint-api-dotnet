using System.Text.Json.Serialization;

namespace savepoint_api_dotnet.Models.Api
{
    public class GameIGDB
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("aggregated_rating")]
        public double AggregatedRating { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("artworks")]
        public List<ArtworkInfo> Artworks { get; set; }
        [JsonPropertyName("cover")]
        public CoverInfo Cover { get; set; }
        [JsonPropertyName("first_release_date")]
        public int ReleaseDateUnix { get; set; }
        [JsonPropertyName("platforms")]
        public List<PlatformInfo> Platforms { get; set; }
        [JsonPropertyName("screenshots")]
        public List<ScreenshotInfo> Images { get; set; }
        [JsonPropertyName("genres")]
        public List<GenreInfo> Genres { get; set; }
        [JsonPropertyName("involved_companies")]
        public List<InvolvedCompanyInfo> InvolvedCompanies { get; set; }
        [JsonPropertyName("summary")]
        public String Description { get; set; }
        [JsonPropertyName("videos")]
        public List<VideoInfo> Videos { get; set; }
        [JsonPropertyName("websites")]
        public List<WebsiteInfo> Websites { get; set; }
    }

    public class CoverInfo
    {
        private string _url;

        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("url")]
        public string Url
        {
            get => _url;
            set => _url = !string.IsNullOrEmpty(value) ? $"https:{value.Replace("t_thumb", "t_1080p")}" : null;
        }
    }

    public class PlatformInfo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public String Platform { get; set; }
        [JsonPropertyName("platform_logo")]
        public PlatformLogo PlatformLogo { get; set; }
        [JsonPropertyName("platform_family")]
        public PlatformFamily PlatformFamily { get; set; }
        [JsonPropertyName("platform_type")]
        public PlatformType PlatformType { get; set; }
        [JsonPropertyName("websites")]
        public List<WebsiteInfo> Websites { get; set; }
    }

    public class PlatformLogo
    {
        private string _url;
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("url")]
        public string Url
        {
            get => _url;
            set => _url = !string.IsNullOrEmpty(value) ? $"https:{value.Replace("t_thumb", "t_1080p")}" : null;
        }
    }

    public class PlatformFamily
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public String Family { get; set; }
    }

    public class PlatformType
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public String Type { get; set; }
    }

    public class ScreenshotInfo
    {
        private string _url;

        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("url")]
        public string Url
        {
            get => _url;
            set => _url = !string.IsNullOrEmpty(value) ? $"https:{value.Replace("t_thumb", "t_1080p")}" : null;
        }
    }
    public class VideoInfo
    {
        private string _url;

        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("video_id")]
        public string Url
        {
            get => _url;
            set => _url = !string.IsNullOrEmpty(value) ? $"https://www.youtube.com/embed/{value}" : null;
        }
    }
    public class WebsiteInfo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("url")]
        public String Url { get; set; }
    }

    public class ArtworkInfo
    {
        private string _url;
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("url")]
        public string Url
        {
            get => _url;
            set => _url = !string.IsNullOrEmpty(value) ? $"https:{value.Replace("t_thumb", "t_1080p")}" : null;
        }
        [JsonPropertyName("artwork_type")]
        public ArtworkTypeInfo? ArtworkType { get; set; }
    }

    public class ArtworkTypeInfo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("slug")]
        public String ArtworkType { get; set; }
    }

    public class GenreInfo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public String Name { get; set; }
    }

    public class InvolvedCompanyInfo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("company")]
        public CompanyInfo Company { get; set; }
        [JsonPropertyName("developer")]
        public bool Developer { get; set; }
    }

    public class CompanyInfo
    {
        private string _countryName;
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("country")]
        public int CountryCode // ISO 3166-1 country code
        { 
            set
            {
                var country = ISO3166.Country.List.FirstOrDefault(c => c.NumericCode == value.ToString());
                if (country != null)
                    _countryName = country.Name;
                else
                    _countryName = "";
            }
        }
        [JsonIgnore]
        public string CountryName => _countryName;
        [JsonPropertyName("logo")]
        public LogoInfo Logo { get; set; }
        [JsonPropertyName("name")]
        public String Name { get; set; }
        [JsonPropertyName("websites")]
        public List<WebsiteInfo> Websites { get; set; }
    }

    public class LogoInfo
    {
        private string _url;
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("url")]
        public string Url
        {
            get => _url;
            set => _url = !string.IsNullOrEmpty(value) ? $"https:{value.Replace("t_thumb", "t_1080p")}" : null;
        }
    }
}