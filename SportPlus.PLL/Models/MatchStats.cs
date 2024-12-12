using System.Text.Json.Serialization;

namespace SportPlus.PLL.Models
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class MatchResponse
    {
        [JsonPropertyName("response")]
        public List<Response>? Response { get; set; }
    }

    public class Match
    {
        [JsonPropertyName("team")]
        public Team? Team { get; set; }

        [JsonPropertyName("statistics")]
        public List<Statistic>? Statistics { get; set; }
    }

    public class Statistic
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("value")]
        public object? Value { get; set; }
    }

    public class MatchTeam
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("logo")]
        public string? Logo { get; set; }
    }
}
