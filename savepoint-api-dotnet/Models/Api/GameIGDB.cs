using System.Text.Json.Serialization;

namespace savepoint_api_dotnet.Models.Api
{
    // TODO: Create a GameIGDBDto class to use when displaying data to the user
    public class GameIGDB
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("aggregated_rating")]
        public double AggregatedRating { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("cover")]
        public CoverInfo Cover { get; set; }
        [JsonPropertyName("first_release_date")]
        public int ReleaseDateUnix { get; set; }
        [JsonPropertyName("platforms")]
        public List<PlatformInfo> Platforms { get; set; }
        [JsonPropertyName("screenshots")]
        public List<ScreenshotInfo> Images { get; set; }
        [JsonPropertyName("summary")]
        public String Description { get; set; }
        [JsonPropertyName("videos")]
        public List<VideoInfo> Videos { get; set; }
        [JsonPropertyName("url")]
        public String Url { get; set; }
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

    //https://www.youtube.com/embed/o9QjlLdYK5I
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
}