using System.Text.Json.Serialization;

namespace SportPlus.PLL.Models
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class TopScorerRoot
    {
        [JsonPropertyName("get")]
        public string? Get { get; set; }

        [JsonPropertyName("parameters")]
        public TopScorerParameters? Parameters { get; set; }

        [JsonPropertyName("errors")]
        public List<object?>? Errors { get; set; }

        [JsonPropertyName("results")]
        public int? Results { get; set; }

        [JsonPropertyName("paging")]
        public TopScorerPaging? Paging { get; set; }

        [JsonPropertyName("response")]
        public List<TopScorerResponse?>? Response { get; set; }
    }
    public class Birth
    {
        [JsonPropertyName("date")]
        public string? Date { get; set; }

        [JsonPropertyName("place")]
        public string? Place { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }
    }

    public class TopScorerCards
    {
        [JsonPropertyName("yellow")]
        public int? Yellow { get; set; }

        [JsonPropertyName("yellowred")]
        public int? Yellowred { get; set; }

        [JsonPropertyName("red")]
        public int? Red { get; set; }
    }

    public class Dribbles
    {
        [JsonPropertyName("attempts")]
        public int? Attempts { get; set; }

        [JsonPropertyName("success")]
        public int? Success { get; set; }

        [JsonPropertyName("past")]
        public object? Past { get; set; }
    }

    public class Duels
    {
        [JsonPropertyName("total")]
        public int? Total { get; set; }

        [JsonPropertyName("won")]
        public int? Won { get; set; }
    }

    public class Fouls
    {
        [JsonPropertyName("drawn")]
        public int? Drawn { get; set; }

        [JsonPropertyName("committed")]
        public int? Committed { get; set; }
    }

    public class Games
    {
        [JsonPropertyName("appearences")]
        public int? Appearences { get; set; }

        [JsonPropertyName("lineups")]
        public int? Lineups { get; set; }

        [JsonPropertyName("minutes")]
        public int? Minutes { get; set; }

        [JsonPropertyName("number")]
        public object? Number { get; set; }

        [JsonPropertyName("position")]
        public string? Position { get; set; }

        [JsonPropertyName("rating")]
        public string? Rating { get; set; }

        [JsonPropertyName("captain")]
        public bool? Captain { get; set; }
    }

    public class TopScorerGoals
    {
        [JsonPropertyName("total")]
        public int? Total { get; set; }

        [JsonPropertyName("conceded")]
        public object? Conceded { get; set; }

        [JsonPropertyName("assists")]
        public int? Assists { get; set; }

        [JsonPropertyName("saves")]
        public int? Saves { get; set; }
    }

    public class TopScorerLeague
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
    }

    public class TopScorerPaging
    {
        [JsonPropertyName("current")]
        public int? Current { get; set; }

        [JsonPropertyName("total")]
        public int? Total { get; set; }
    }

    public class TopScorerParameters
    {
        [JsonPropertyName("league")]
        public string? League { get; set; }

        [JsonPropertyName("season")]
        public string? Season { get; set; }
    }

    public class TopScorerPasses
    {
        [JsonPropertyName("total")]
        public int? Total { get; set; }

        [JsonPropertyName("key")]
        public int? Key { get; set; }

        [JsonPropertyName("accuracy")]
        public int? Accuracy { get; set; }
    }

    public class TopScorerPenalty
    {
        [JsonPropertyName("won")]
        public int? Won { get; set; }

        [JsonPropertyName("commited")]
        public object? Commited { get; set; }

        [JsonPropertyName("scored")]
        public int? Scored { get; set; }

        [JsonPropertyName("missed")]
        public int? Missed { get; set; }

        [JsonPropertyName("saved")]
        public object? Saved { get; set; }
    }

    public class TopScorerPlayer
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("firstname")]
        public string? Firstname { get; set; }

        [JsonPropertyName("lastname")]
        public string? Lastname { get; set; }

        [JsonPropertyName("age")]
        public int? Age { get; set; }

        [JsonPropertyName("birth")]
        public Birth? Birth { get; set; }

        [JsonPropertyName("nationality")]
        public string? Nationality { get; set; }

        [JsonPropertyName("height")]
        public string? Height { get; set; }

        [JsonPropertyName("weight")]
        public string? Weight { get; set; }

        [JsonPropertyName("injured")]
        public bool? Injured { get; set; }

        [JsonPropertyName("photo")]
        public string? Photo { get; set; }
    }

    public class TopScorerResponse
    {
        [JsonPropertyName("player")]
        public TopScorerPlayer? Player { get; set; }

        [JsonPropertyName("statistics")]
        public List<Statistic?>? Statistics { get; set; }
    }


    public class Shots
    {
        [JsonPropertyName("total")]
        public int? Total { get; set; }

        [JsonPropertyName("on")]
        public int? On { get; set; }
    }

    public class Statistic
    {
        [JsonPropertyName("team")]
        public TopScorerTeam? Team { get; set; }

        [JsonPropertyName("league")]
        public TopScorerLeague? League { get; set; }

        [JsonPropertyName("games")]
        public Games? Games { get; set; }

        [JsonPropertyName("substitutes")]
        public Substitutes? Substitutes { get; set; }

        [JsonPropertyName("shots")]
        public Shots? Shots { get; set; }

        [JsonPropertyName("goals")]
        public TopScorerGoals? Goals { get; set; }

        [JsonPropertyName("passes")]
        public TopScorerPasses? Passes { get; set; }

        [JsonPropertyName("tackles")]
        public Tackles? Tackles { get; set; }

        [JsonPropertyName("duels")]
        public Duels? Duels { get; set; }

        [JsonPropertyName("dribbles")]
        public Dribbles? Dribbles { get; set; }

        [JsonPropertyName("fouls")]
        public Fouls? Fouls { get; set; }

        [JsonPropertyName("cards")]
        public Cards? Cards { get; set; }

        [JsonPropertyName("penalty")]
        public TopScorerPenalty? Penalty { get; set; }
    }

    public class Substitutes
    {
        [JsonPropertyName("in")]
        public int? In { get; set; }

        [JsonPropertyName("out")]
        public int? Out { get; set; }

        [JsonPropertyName("bench")]
        public int? Bench { get; set; }
    }

    public class Tackles
    {
        [JsonPropertyName("total")]
        public int? Total { get; set; }

        [JsonPropertyName("blocks")]
        public int? Blocks { get; set; }

        [JsonPropertyName("interceptions")]
        public int? Interceptions { get; set; }
    }

    public class TopScorerTeam
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("logo")]
        public string? Logo { get; set; }
    }
}
