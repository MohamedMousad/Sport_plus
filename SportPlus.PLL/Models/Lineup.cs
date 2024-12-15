using System.Text.Json.Serialization;

namespace SportPlus.PLL.Models
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<LineupRoot>(myJsonResponse);
    public class Coach
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("photo")]
        public string? Photo { get; set; }
    }

    public class Colors
    {
        [JsonPropertyName("player")]
        public Player? Player { get; set; }

        [JsonPropertyName("goalkeeper")]
        public Goalkeeper? Goalkeeper { get; set; }
    }

    public class Goalkeeper
    {
        [JsonPropertyName("primary")]
        public string? Primary { get; set; }

        [JsonPropertyName("number")]
        public string? Number { get; set; }

        [JsonPropertyName("border")]
        public string? Border { get; set; }
    }

    public class Paging
    {
        [JsonPropertyName("current")]
        public int? Current { get; set; }

        [JsonPropertyName("total")]
        public int? Total { get; set; }
    }

    public class Parameters
    {
        [JsonPropertyName("fixture")]
        public string? Fixture { get; set; }
    }

    public class Player
    {
        [JsonPropertyName("primary")]
        public string? Primary { get; set; }

        [JsonPropertyName("number")]
        public string? Number { get; set; }

        [JsonPropertyName("border")]
        public string? Border { get; set; }

        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("pos")]
        public string? Pos { get; set; }

        [JsonPropertyName("grid")]
        public string? Grid { get; set; }
    }

    public class LineupResponse
    {
        [JsonPropertyName("team")]
        public TeamLineup? Team { get; set; }

        [JsonPropertyName("formation")]
        public string? Formation { get; set; }

        [JsonPropertyName("startXI")]
        public List<StartXI?>? StartXI { get; set; }

        [JsonPropertyName("substitutes")]
        public List<Substitute?>? Substitutes { get; set; }

        [JsonPropertyName("coach")]
        public Coach? Coach { get; set; }
    }

    public class LineupRoot
    {
        [JsonPropertyName("get")]
        public string? Get { get; set; }

        [JsonPropertyName("parameters")]
        public Parameters? Parameters { get; set; }

        [JsonPropertyName("errors")]
        public object? Errors { get; set; }

        [JsonPropertyName("results")]
        public int? Results { get; set; }

        [JsonPropertyName("paging")]
        public Paging? Paging { get; set; }

        [JsonPropertyName("response")]
        public List<LineupResponse?>? Response { get; set; }
    }

    public class StartXI
    {
        [JsonPropertyName("player")]
        public Player? Player { get; set; }
    }

    public class Substitute
    {
        [JsonPropertyName("player")]
        public Player? Player { get; set; }
    }

    public class TeamLineup
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("logo")]
        public string? Logo { get; set; }

        [JsonPropertyName("colors")]
        public Colors? Colors { get; set; }
    }


}
