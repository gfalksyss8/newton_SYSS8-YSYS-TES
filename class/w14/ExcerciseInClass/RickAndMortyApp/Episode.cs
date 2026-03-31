using System.Text.Json.Serialization;

namespace RickAndMortyApp;

public class Episode
{
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("air_date")]
    public string AirDate { get; set; } = string.Empty;

    [JsonPropertyName("episode")]
    public string EpisodeCode { get; set; } = string.Empty;

    [JsonPropertyName("created")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("characters")]
    public List<string> Characters { get; set; }
}
