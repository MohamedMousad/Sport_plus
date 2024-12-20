﻿using System.Text.Json.Serialization;
namespace SportPlus.PLL.Models
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Fixtures>(myJsonResponse);
    public class FixtureResponse
    {
        [JsonPropertyName("response")]
        public List<Response>? Response { get; set; }
    }
    public class Response
    {
        [JsonPropertyName("fixture")]
        public Fixture? Fixture { get; set; }

        [JsonPropertyName("league")]
        public League? League { get; set; }

        [JsonPropertyName("teams")]
        public Teams? Teams { get; set; }

        [JsonPropertyName("goals")]
        public Goals? Goals { get; set; }

        [JsonPropertyName("score")]
        public Score? Score { get; set; }
    }
    public class Fixture
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("referee")]
        public object? Referee { get; set; }

        [JsonPropertyName("timezone")]
        public string? Timezone { get; set; }

        [JsonPropertyName("date")]
        public DateTime? Date { get; set; }

        [JsonPropertyName("timestamp")]
        public int? Timestamp { get; set; }

        [JsonPropertyName("periods")]
        public Periods? Periods { get; set; }

        [JsonPropertyName("venue")]
        public Venue? Venue { get; set; }

        [JsonPropertyName("status")]
        public Status? Status { get; set; }
    }
    public class League
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

        [JsonPropertyName("round")]
        public string? Round { get; set; }
    }
    public class Teams
    {
        [JsonPropertyName("home")]
        public Home? Home { get; set; }

        [JsonPropertyName("away")]
        public Away? Away { get; set; }
    }

    public class Home
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("logo")]
        public string? Logo { get; set; }

        [JsonPropertyName("winner")]
        public bool? Winner { get; set; }
    }

    public class Away
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("logo")]
        public string? Logo { get; set; }

        [JsonPropertyName("winner")]
        public bool? Winner { get; set; }
    }
    public class Goals
    {
        [JsonPropertyName("home")]
        public int? Home { get; set; }

        [JsonPropertyName("away")]
        public int? Away { get; set; }
    }
    public class Score
    {
        [JsonPropertyName("halftime")]
        public Halftime? Halftime { get; set; }

        [JsonPropertyName("fulltime")]
        public Fulltime? Fulltime { get; set; }

        [JsonPropertyName("extratime")]
        public Extratime? Extratime { get; set; }

        [JsonPropertyName("penalty")]
        public Penalty? Penalty { get; set; }
    }

    public class Halftime
    {
        [JsonPropertyName("home")]
        public int? Home { get; set; }

        [JsonPropertyName("away")]
        public int? Away { get; set; }
    }
    public class Fulltime
    {
        [JsonPropertyName("home")]
        public object? Home { get; set; }

        [JsonPropertyName("away")]
        public object? Away { get; set; }
    }

    public class Extratime
    {
        [JsonPropertyName("home")]
        public object? Home { get; set; }

        [JsonPropertyName("away")]
        public object? Away { get; set; }
    }

    public class Penalty
    {
        [JsonPropertyName("home")]
        public object? Home { get; set; }

        [JsonPropertyName("away")]
        public object? Away { get; set; }
    }

    public class Periods
    {
        [JsonPropertyName("first")]
        public int? First { get; set; }

        [JsonPropertyName("second")]
        public object? Second { get; set; }
    }

    public class Status
    {
        [JsonPropertyName("long")]
        public string? Long { get; set; }

        [JsonPropertyName("short")]
        public string? Short { get; set; }

        [JsonPropertyName("elapsed")]
        public int? Elapsed { get; set; }

        [JsonPropertyName("extra")]
        public object? Extra { get; set; }
    }


    public class Venue
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("city")]
        public string? City { get; set; }
    }
}