using Newtonsoft.Json;

namespace SportPlus.PLL.Models
{
    public class TeamRoot
    {
        public Response Response { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class _015
    {
        public int? Total { get; set; }
        public string? Percentage { get; set; }
    }

    public class _05
    {
        public int? Over { get; set; }
        public int? Under { get; set; }
    }

    public class _106120
    {
        public object? Total { get; set; }
        public object? Percentage { get; set; }
    }

    public class _15
    {
        public int? Over { get; set; }
        public int? Under { get; set; }
    }

    public class _1630
    {
        public int? Total { get; set; }
        public string? Percentage { get; set; }
    }

    public class _25
    {
        public int? Over { get; set; }
        public int? Under { get; set; }
    }

    public class _3145
    {
        public int? Total { get; set; }
        public string Percentage { get; set; }
    }

    public class _35
    {
        public int? Over { get; set; }
        public int? Under { get; set; }
    }

    public class _45
    {
        public int? Over { get; set; }
        public int? Under { get; set; }
    }

    public class _4660
    {
        public int? Total { get; set; }
        public string? Percentage { get; set; }
    }

    public class _6175
    {
        public int? Total { get; set; }
        public string? Percentage { get; set; }
    }

    public class _7690
    {
        public int? Total { get; set; }
        public string Percentage { get; set; }
    }

    public class _91105
    {
        public int? Total { get; set; }
        public string? Percentage { get; set; }
    }

    public class Against
    {
        public TotalGames? Total { get; set; }
        public Average? Average { get; set; }
        public Minute? Minute { get; set; }
        public UnderOver? UnderOver { get; set; }
        public int? Home { get; set; }
        public int? Away { get; set; }
    }

    public class Average
    {
        public string? Home { get; set; }
        public string? Away { get; set; }
        public string? Total { get; set; }
    }

    public class Biggest
    {
        public Streak? Streak { get; set; }
        public Wins? Wins { get; set; }
        public Loses? Loses { get; set; }
        public Goals? Goals { get; set; }
    }

    public class Cards
    {
        public Yellow? Yellow { get; set; }
        public Red? Red { get; set; }
    }

    public class CleanSheet
    {
        public int? Home { get; set; }
        public int? Away { get; set; }
        public int? Total { get; set; }
    }

    public class Draws
    {
        public int? Home { get; set; }
        public int? Away { get; set; }
        public int? Total { get; set; }
    }

    public class FailedToScore
    {
        public int? Home { get; set; }
        public int? Away { get; set; }
        public int? Total { get; set; }
    }

    public class Fixtures
    {
        public Played? Played { get; set; }
        public Wins? Wins { get; set; }
        public Draws? Draws { get; set; }
        public Loses? Loses { get; set; }
    }

    public class For
    {
        public TotalGames? Total { get; set; }
        public Average? Average { get; set; }
        public Minute? Minute { get; set; }
        public UnderOver? UnderOver { get; set; }
        public int? Home { get; set; }
        public int? Away { get; set; }
    }

    public class TeamGoals
    {
        public For? For { get; set; }
        public Against? Against { get; set; }
    }

    public class TeamLeague
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? Logo { get; set; }
        public string? Flag { get; set; }
        public int? Season { get; set; }
    }

    public class Lineup
    {
        public string? Formation { get; set; }
        public int? Played { get; set; }
    }

    public class Loses
    {
        public int? Home { get; set; }
        public int? Away { get; set; }
        public int? Total { get; set; }
    }

    public class Minute
    {
        [JsonProperty("0-15")]
        public _015? _015 { get; set; }

        [JsonProperty("16-30")]
        public _1630? _1630 { get; set; }

        [JsonProperty("31-45")]
        public _3145? _3145 { get; set; }

        [JsonProperty("46-60")]
        public _4660? _4660 { get; set; }

        [JsonProperty("61-75")]
        public _6175? _6175 { get; set; }

        [JsonProperty("76-90")]
        public _7690? _7690 { get; set; }

        [JsonProperty("91-105")]
        public _91105? _91105 { get; set; }

        [JsonProperty("106-120")]
        public _106120? _106120 { get; set; }
    }

    public class Missed
    {
        public int? Total { get; set; }
        public string? Percentage { get; set; }
    }

    public class TeamPenalty
    {
        public Scored? Scored { get; set; }
        public Missed? Missed { get; set; }
        public int? Total { get; set; }
    }

    public class Played
    {
        public int? Home { get; set; }
        public int? Away { get; set; }
        public int? Total { get; set; }
    }

    public class Red
    {
        [JsonProperty("0-15")]
        public _015? _015 { get; set; }

        [JsonProperty("16-30")]
        public _1630? _1630 { get; set; }

        [JsonProperty("31-45")]
        public _3145? _3145 { get; set; }

        [JsonProperty("46-60")]
        public _4660? _4660 { get; set; }

        [JsonProperty("61-75")]
        public _6175? _6175 { get; set; }

        [JsonProperty("76-90")]
        public _7690? _7690 { get; set; }

        [JsonProperty("91-105")]
        public _91105? _91105 { get; set; }

        [JsonProperty("106-120")]
        public _106120? _106120 { get; set; }
    }

    public class TeamResponse
    {
        public League? League { get; set; }
        public Team? Team { get; set; }
        public string? Form { get; set; }
        public Fixtures? Fixtures { get; set; }
        public Goals? Goals { get; set; }
        public Biggest? Biggest { get; set; }
        public CleanSheet? CleanSheet { get; set; }
        public FailedToScore? FailedToScore { get; set; }
        public Penalty? Penalty { get; set; }
        public List<Lineup>? Lineups { get; set; }
        public Cards? Cards { get; set; }
    }


    public class Scored
    {
        public int? Total { get; set; }
        public string? Percentage { get; set; }
    }

    public class Streak
    {
        public int? Wins { get; set; }
        public int? Draws { get; set; }
        public int? Loses { get; set; }
    }

    public class Team
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Logo { get; set; }
    }

    public class TotalGames
    {
        public int? Home { get; set; }
        public int? Away { get; set; }
        public int? Total { get; set; }
    }

    public class UnderOver
    {
        [JsonProperty("0.5")]
        public _05? _05 { get; set; }

        [JsonProperty("1.5")]
        public _15? _15 { get; set; }

        [JsonProperty("2.5")]
        public _25? _25 { get; set; }

        [JsonProperty("3.5")]
        public _35? _35 { get; set; }

        [JsonProperty("4.5")]
        public _45? _45 { get; set; }
    }

    public class Wins
    {
        public int? Home { get; set; }
        public int? Away { get; set; }
        public int? Total { get; set; }
    }

    public class Yellow
    {
        [JsonProperty("0-15")]
        public _015? _015 { get; set; }

        [JsonProperty("16-30")]
        public _1630? _1630 { get; set; }

        [JsonProperty("31-45")]
        public _3145? _3145 { get; set; }

        [JsonProperty("46-60")]
        public _4660? _4660 { get; set; }

        [JsonProperty("61-75")]
        public _6175? _6175 { get; set; }

        [JsonProperty("76-90")]
        public _7690? _7690 { get; set; }

        [JsonProperty("91-105")]
        public _91105? _91105 { get; set; }

        [JsonProperty("106-120")]
        public _106120? _106120 { get; set; }
    }


}
