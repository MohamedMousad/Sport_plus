using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace SportPlus.PLL.Models
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<TeamRoot>(myJsonResponse);
    public class TeamRoot
    {
        [JsonPropertyName("get")]
        public string? Get { get; set; }

        [JsonPropertyName("parameters")]
        public TeamStatsParameters? Parameters { get; set; }

        [JsonPropertyName("errors")]
        public object? Errors { get; set; }

        [JsonPropertyName("results")]
        public int? Results { get; set; }

        [JsonPropertyName("paging")]
        public TeamStatsPaging? Paging { get; set; }

        [JsonPropertyName("response")]
        public List<TeamStatsResponse?>? Response { get; set; } // Change this to a list
    }

    public class TeamStatsResponse
    {
        [JsonPropertyName("league")]
        public TeamStatsLeague? League { get; set; }

        [JsonPropertyName("team")]
        public Team? Team { get; set; }

        [JsonPropertyName("form")]
        public string? Form { get; set; }

        [JsonPropertyName("fixtures")]
        public Fixtures? Fixtures { get; set; }

        [JsonPropertyName("goals")]
        public TeamStatsGoals? Goals { get; set; }

        [JsonPropertyName("biggest")]
        public Biggest? Biggest { get; set; }

        [JsonPropertyName("clean_sheet")]
        public CleanSheet? CleanSheet { get; set; }

        [JsonPropertyName("failed_to_score")]
        public FailedToScore? FailedToScore { get; set; }

        [JsonPropertyName("penalty")]
        public TeamStatsPenalty? Penalty { get; set; }

        [JsonPropertyName("lineups")]
        public List<Lineup?>? Lineups { get; set; }

        [JsonPropertyName("cards")]
        public Cards? Cards { get; set; }
    }

    public class TeamStatsLeague
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

    public class Against
    {
        [JsonPropertyName("total")]
        public TotalGames? Total { get; set; }

        [JsonPropertyName("average")]
        public Average? Average { get; set; }

        [JsonPropertyName("minute")]
        public Minute? Minute { get; set; }

        [JsonPropertyName("under_over")]
        public UnderOver? UnderOver { get; set; }

        [JsonPropertyName("home")]
        public int? Home { get; set; }

        [JsonPropertyName("away")]
        public int? Away { get; set; }
    }

    public class Average
    {
        [JsonPropertyName("home")]
        public string? Home { get; set; }

        [JsonPropertyName("away")]
        public string? Away { get; set; }

        [JsonPropertyName("total")]
        public string? Total { get; set; }
    }

    public class Biggest
    {
        [JsonPropertyName("streak")]
        public Streak? Streak { get; set; }

        [JsonPropertyName("wins")]
        public Wins? Wins { get; set; }

        [JsonPropertyName("loses")]
        public Loses? Loses { get; set; }

        [JsonPropertyName("goals")]
        public TeamStatsGoals? Goals { get; set; }
    }

    public class Cards
    {
        [JsonPropertyName("yellow")]
        public Yellow? Yellow { get; set; }

        [JsonPropertyName("red")]
        public Red? Red { get; set; }
    }

    public class CleanSheet
    {
        [JsonPropertyName("home")]
        public int? Home { get; set; }

        [JsonPropertyName("away")]
        public int? Away { get; set; }

        [JsonPropertyName("total")]
        public int? Total { get; set; }
    }

    public class Draws
    {
        [JsonPropertyName("home")]
        public int? Home { get; set; }

        [JsonPropertyName("away")]
        public int? Away { get; set; }

        [JsonPropertyName("total")]
        public int? Total { get; set; }
    }

    public class FailedToScore
    {
        [JsonPropertyName("home")]
        public int? Home { get; set; }

        [JsonPropertyName("away")]
        public int? Away { get; set; }

        [JsonPropertyName("total")]
        public int? Total { get; set; }
    }

    public class Fixtures
    {
        [JsonPropertyName("played")]
        public Played? Played { get; set; }

        [JsonPropertyName("wins")]
        public Wins? Wins { get; set; }

        [JsonPropertyName("draws")]
        public Draws? Draws { get; set; }

        [JsonPropertyName("loses")]
        public Loses? Loses { get; set; }
    }

    public class For
    {
        [JsonPropertyName("total")]
        public TotalGames? Total { get; set; }

        [JsonPropertyName("average")]
        public Average? Average { get; set; }

        [JsonPropertyName("minute")]
        public Minute? Minute { get; set; }

        [JsonPropertyName("under_over")]
        public UnderOver? UnderOver { get; set; }

        [JsonPropertyName("home")]
        public int? Home { get; set; }

        [JsonPropertyName("away")]
        public int? Away { get; set; }
    }

    public class TeamStatsGoals
    {
        [JsonPropertyName("for")]
        public For? For { get; set; }

        [JsonPropertyName("against")]
        public Against? Against { get; set; }
    }

    public class Lineup
    {
        [JsonPropertyName("formation")]
        public string? Formation { get; set; }

        [JsonPropertyName("played")]
        public int? Played { get; set; }
    }

    public class Loses
    {
        [JsonPropertyName("home")]
        public int? Home { get; set; }

        [JsonPropertyName("away")]
        public int? Away { get; set; }

        [JsonPropertyName("total")]
        public int? Total { get; set; }
    }

    public class Minute
    {
        [JsonPropertyName("0-15")]
        public _015? _015 { get; set; }

        [JsonPropertyName("16-30")]
        public _1630? _1630 { get; set; }

        [JsonPropertyName("31-45")]
        public _3145? _3145 { get; set; }

        [JsonPropertyName("46-60")]
        public _4660? _4660 { get; set; }

        [JsonPropertyName("61-75")]
        public _6175? _6175 { get; set; }

        [JsonPropertyName("76-90")]
        public _7690? _7690 { get; set; }

        [JsonPropertyName("91-105")]
        public _91105? _91105 { get; set; }

        [JsonPropertyName("106-120")]
        public _106120? _106120 { get; set; }
    }

    public class Missed
    {
        [JsonPropertyName("total")]
        public int? Total { get; set; }

        [JsonPropertyName("percentage")]
        public string? Percentage { get; set; }
    }

    public class TeamStatsPaging
    {
        [JsonPropertyName("current")]
        public int? Current { get; set; }

        [JsonPropertyName("total")]
        public int? Total { get; set; }
    }

    public class TeamStatsParameters
    {
        [JsonPropertyName("league")]
        public string? League { get; set; }

        [JsonPropertyName("season")]
        public string? Season { get; set; }

        [JsonPropertyName("team")]
        public string? Team { get; set; }
    }

    public class TeamStatsPenalty
    {
        [JsonPropertyName("scored")]
        public Scored? Scored { get; set; }

        [JsonPropertyName("missed")]
        public Missed? Missed { get; set; }

        [JsonPropertyName("total")]
        public int? Total { get; set; }
    }

    public class Played
    {
        [JsonPropertyName("home")]
        public int? Home { get; set; }

        [JsonPropertyName("away")]
        public int? Away { get; set; }

        [JsonPropertyName("total")]
        public int? Total { get; set; }
    }

    public class Red
    {
        [JsonPropertyName("0-15")]
        public _015? _015 { get; set; }

        [JsonPropertyName("16-30")]
        public _1630? _1630 { get; set; }

        [JsonPropertyName("31-45")]
        public _3145? _3145 { get; set; }

        [JsonPropertyName("46-60")]
        public _4660? _4660 { get; set; }

        [JsonPropertyName("61-75")]
        public _6175? _6175 { get; set; }

        [JsonPropertyName("76-90")]
        public _7690? _7690 { get; set; }

        [JsonPropertyName("91-105")]
        public _91105? _91105 { get; set; }

        [JsonPropertyName("106-120")]
        public _106120? _106120 { get; set; }
    }

    public class Scored
    {
        [JsonPropertyName("total")]
        public int? Total { get; set; }

        [JsonPropertyName("percentage")]
        public string? Percentage { get; set; }
    }

    public class Streak
    {
        [JsonPropertyName("wins")]
        public int? Wins { get; set; }

        [JsonPropertyName("draws")]
        public int? Draws { get; set; }

        [JsonPropertyName("loses")]
        public int? Loses { get; set; }
    }

    public class Team
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("logo")]
        public string? Logo { get; set; }
    }

    public class TotalGames
    {
        [JsonPropertyName("home")]
        public int? Home { get; set; }

        [JsonPropertyName("away")]
        public int? Away { get; set; }

        [JsonPropertyName("total")]
        public int? Total { get; set; }
    }

    public class UnderOver
    {
        [JsonPropertyName("0.5")]
        public _05? _05 { get; set; }

        [JsonPropertyName("1.5")]
        public _15? _15 { get; set; }

        [JsonPropertyName("2.5")]
        public _25? _25 { get; set; }

        [JsonPropertyName("3.5")]
        public _35? _35 { get; set; }

        [JsonPropertyName("4.5")]
        public _45? _45 { get; set; }
    }

    public class Wins
    {
        [JsonPropertyName("home")]
        public int? Home { get; set; }

        [JsonPropertyName("away")]
        public int? Away { get; set; }

        [JsonPropertyName("total")]
        public int? Total { get; set; }
    }

    public class Yellow
    {
        [JsonPropertyName("0-15")]
        public _015? _015 { get; set; }

        [JsonPropertyName("16-30")]
        public _1630? _1630 { get; set; }

        [JsonPropertyName("31-45")]
        public _3145? _3145 { get; set; }

        [JsonPropertyName("46-60")]
        public _4660? _4660 { get; set; }

        [JsonPropertyName("61-75")]
        public _6175? _6175 { get; set; }

        [JsonPropertyName("76-90")]
        public _7690? _7690 { get; set; }

        [JsonPropertyName("91-105")]
        public _91105? _91105 { get; set; }

        [JsonPropertyName("106-120")]
        public _106120? _106120 { get; set; }
    }

    public class _015
    {
        [JsonPropertyName("total")]
        public int? Total { get; set; }

        [JsonPropertyName("percentage")]
        public string? Percentage { get; set; }
    }

    public class _05
    {
        [JsonPropertyName("over")]
        public int? Over { get; set; }

        [JsonPropertyName("under")]
        public int? Under { get; set; }
    }

    public class _106120
    {
        [JsonPropertyName("total")]
        public object? Total { get; set; }

        [JsonPropertyName("percentage")]
        public object? Percentage { get; set; }
    }

    public class _15
    {
        [JsonPropertyName("over")]
        public int? Over { get; set; }

        [JsonPropertyName("under")]
        public int? Under { get; set; }
    }

    public class _1630
    {
        [JsonPropertyName("total")]
        public int? Total { get; set; }

        [JsonPropertyName("percentage")]
        public string? Percentage { get; set; }
    }

    public class _25
    {
        [JsonPropertyName("over")]
        public int? Over { get; set; }

        [JsonPropertyName("under")]
        public int? Under { get; set; }
    }

    public class _3145
    {
        [JsonPropertyName("total")]
        public int? Total { get; set; }

        [JsonPropertyName("percentage")]
        public string? Percentage { get; set; }
    }

    public class _35
    {
        [JsonPropertyName("over")]
        public int? Over { get; set; }

        [JsonPropertyName("under")]
        public int? Under { get; set; }
    }

    public class _45
    {
        [JsonPropertyName("over")]
        public int? Over { get; set; }

        [JsonPropertyName("under")]
        public int? Under { get; set; }
    }

    public class _4660
    {
        [JsonPropertyName("total")]
        public int? Total { get; set; }

        [JsonPropertyName("percentage")]
        public string? Percentage { get; set; }
    }

    public class _6175
    {
        [JsonPropertyName("total")]
        public int? Total { get; set; }

        [JsonPropertyName("percentage")]
        public string? Percentage { get; set; }
    }

    public class _7690
    {
        [JsonPropertyName("total")]
        public int? Total { get; set; }

        [JsonPropertyName("percentage")]
        public string? Percentage { get; set; }
    }

    public class _91105
    {
        [JsonPropertyName("total")]
        public int? Total { get; set; }

        [JsonPropertyName("percentage")]
        public string? Percentage { get; set; }
    }
}
