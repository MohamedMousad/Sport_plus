// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
using System.Text.Json.Serialization;

public class Paging
{
    [JsonPropertyName("current")]
    public int? Current { get; set; }

    [JsonPropertyName("total")]
    public int? Total { get; set; }
}

public class Parameters
{
    [JsonPropertyName("team")]
    public string? Team { get; set; }

    [JsonPropertyName("fixture")]
    public string? Fixture { get; set; }
}

public class MatchResponse
{
    [JsonPropertyName("team")]
    public MatchTeam? Team { get; set; }

    [JsonPropertyName("statistics")]
    public List<Statistic>? Statistics { get; set; }
    public TeamStatistics? FormattedStatistics { get; set; }
}

public class MatchRoot
{
    [JsonPropertyName("get")]
    public string? Get { get; set; }

    [JsonPropertyName("parameters")]
    public Parameters? Parameters { get; set; }

    [JsonPropertyName("errors")]
    public List<object>? Errors { get; set; }

    [JsonPropertyName("results")]
    public int? Results { get; set; }

    [JsonPropertyName("paging")]
    public Paging? Paging { get; set; }

    [JsonPropertyName("response")]
    public List<MatchResponse>? Response { get; set; }
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
public class TeamStatistics
{
    public int? ShotsOnGoal { get; set; }
    public int? ShotsOffGoal { get; set; }
    public int? TotalShots { get; set; }
    public int? BlockedShots { get; set; }
    public int ShotsInsideBox { get; set; }
    public int? ShotsOutsideBox { get; set; }
    public int? Fouls { get; set; }
    public int? CornerKicks { get; set; }
    public int? Offsides { get; set; }
    public string? BallPossession { get; set; }
    public int? YellowCards { get; set; }
    public int? RedCards { get; set; }
    public int? GoalkeeperSaves { get; set; }
    public int? TotalPasses { get; set; }
    public int? PassesAccurate { get; set; }
    public string? PassesPercentage { get; set; }
    public string? ExpectedGoals { get; set; }
    public int? GoalsPrevented { get; set; }
}


public class MatchStatisticsMapper
{
    public static TeamStatistics? MapStatistics(List<Statistic> statistics)
    {
        var stats = new TeamStatistics();

        foreach (var item in statistics)
        {
            switch (item.Type)
            {
                case "Shots on Goal":
                    stats.ShotsOnGoal = item.Value != null ? Convert.ToInt32(item.Value) : 0;
                    break;
                case "Shots off Goal":
                    stats.ShotsOffGoal = item.Value != null ? Convert.ToInt32(item.Value) : 0;
                    break;
                case "Total Shots":
                    stats.TotalShots = item.Value != null ? Convert.ToInt32(item.Value) : 0;
                    break;
                case "Blocked Shots":
                    stats.BlockedShots = item.Value != null ? Convert.ToInt32(item.Value) : 0;
                    break;
                case "Shots insidebox":
                    stats.ShotsInsideBox = item.Value != null ? Convert.ToInt32(item.Value) : 0;
                    break;
                case "Shots outsidebox":
                    stats.ShotsOutsideBox = item.Value != null ? Convert.ToInt32(item.Value) : 0;
                    break;
                case "Fouls":
                    stats.Fouls = item.Value != null ? Convert.ToInt32(item.Value) : 0;
                    break;
                case "Corner Kicks":
                    stats.CornerKicks = item.Value != null ? Convert.ToInt32(item.Value) : 0;
                    break;
                case "Offsides":
                    stats.Offsides = item.Value != null ? Convert.ToInt32(item.Value) : 0;
                    break;
                case "Ball Possession":
                    stats.BallPossession = item.Value?.ToString() ?? "0%";
                    break;
                case "Yellow Cards":
                    stats.YellowCards = item.Value != null ? Convert.ToInt32(item.Value) : 0;
                    break;
                case "Red Cards":
                    stats.RedCards = item.Value != null ? (int?)Convert.ToInt32(item.Value) : null;
                    break;
                case "Goalkeeper Saves":
                    stats.GoalkeeperSaves = item.Value != null ? (int?)Convert.ToInt32(item.Value) : null;
                    break;
                case "Total passes":
                    stats.TotalPasses = item.Value != null ? Convert.ToInt32(item.Value) : 0;
                    break;
                case "Passes accurate":
                    stats.PassesAccurate = item.Value != null ? Convert.ToInt32(item.Value) : 0;
                    break;
                case "Passes %":
                    stats.PassesPercentage = item.Value?.ToString() ?? "0%";
                    break;
                case "expected_goals":
                    stats.ExpectedGoals = item.Value?.ToString() ?? "0.00";
                    break;
                case "goals_prevented":
                    stats.GoalsPrevented = item.Value != null ? Convert.ToInt32(item.Value) : 0;
                    break;
            }
        }

        return stats;
    }
}
