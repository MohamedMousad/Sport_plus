using System.Text.Json.Serialization;

namespace SportPlus.PLL.Models
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class StandingRoot
    {
        [JsonPropertyName("response")]
        public List<LeagueResponse?>? Response { get; set; }
    }
    public class LeagueResponse
    {
        [JsonPropertyName("league")]
        public LeagueData? League { get; set; }
    }
    public class LeagueData
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("logo")]
        public string? Logo { get; set; }

        [JsonPropertyName("flag")]
        public string? Flag { get; set; }

        [JsonPropertyName("season")]
        public int? Season { get; set; }

        [JsonPropertyName("standings")]
        public List<List<Standing?>?>? Standings { get; set; }
    }
    public class Standing
    {
        [JsonPropertyName("rank")]
        public int? Rank { get; set; }

        [JsonPropertyName("team")]
        public SeasonTeam? Team { get; set; }

        [JsonPropertyName("points")]
        public int? Points { get; set; }

        [JsonPropertyName("goalsDiff")]
        public int? GoalsDiff { get; set; }

        [JsonPropertyName("group")]
        public string? Group { get; set; }

        [JsonPropertyName("form")]
        public string? Form { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("all")]
        public Stats? All { get; set; }

        [JsonPropertyName("home")]
        public Stats? Home { get; set; }

        [JsonPropertyName("away")]
        public Stats? Away { get; set; }

        [JsonPropertyName("update")]
        public string? Update { get; set; }
    }
    public class SeasonTeam
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("logo")]
        public string? Logo { get; set; }
    }
    public class Stats
    {
        [JsonPropertyName("played")]
        public int? Played { get; set; }
        [JsonPropertyName("win")]
        public int? Win { get; set; }
        [JsonPropertyName("draw")]
        public int? Draw { get; set; }
        [JsonPropertyName("lose")]
        public int? Lose { get; set; }
        [JsonPropertyName("goals")]
        public SeasonGoals? Goals { get; set; }
    }
    public class SeasonGoals
    {
        [JsonPropertyName("for")]
        public int? For { get; set; }

        [JsonPropertyName("against")]
        public int? Against { get; set; }
    }
}