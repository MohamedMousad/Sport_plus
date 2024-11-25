using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using SportPlus.PLL.Models;  // Ensure you have the correct namespace for your models
//using Microsoft.AspNetCore.Mvc;
//using System.Net.Http;
//using System.Threading.Tasks;
//using Newtonsoft.Json;
//using System.Collections.Generic;  // Make sure to include this for List<T>
//using SportPlus.PLL.Models; // Ensure this namespace contains the FootballResult class

public class ApiResponse
{
    public string Get { get; set; }
    public Parameters Parameters { get; set; }
    public List<string> Errors { get; set; }
    public int Results { get; set; }
    public Paging Paging { get; set; }
    public List<LeagueResponse> Response { get; set; }
}

public class Parameters
{
    public string Id { get; set; }
}

public class Paging
{
    public int Current { get; set; }
    public int Total { get; set; }
}

public class LeagueResponse
{
    public League League { get; set; }
    public Country Country { get; set; }
    public List<Season> Seasons { get; set; }
    public List<Season> Leagues { get; set; }

}

public class League
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Logo { get; set; }
}

public class Country
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string Flag { get; set; }
}

public class Season
{
    public int Year { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public bool Current { get; set; }
    public Coverage Coverage { get; set; }
}

public class Coverage
{
    public Fixtures Fixtures { get; set; }
    public bool Standings { get; set; }
    public bool Players { get; set; }
    public bool TopScorers { get; set; }
    public bool TopAssists { get; set; }
    public bool TopCards { get; set; }
    public bool Injuries { get; set; }
    public bool Predictions { get; set; }
    public bool Odds { get; set; }
}

public class Fixtures
{
    public bool Events { get; set; }
    public bool Lineups { get; set; }
    public bool StatisticsFixtures { get; set; }
    public bool StatisticsPlayers { get; set; }
}


public class FootballController : Controller
{
    private readonly HttpClient _client;

    // Constructor to inject HttpClient
    public FootballController(HttpClient client)
    {
        _client = client;
        _client.BaseAddress = new Uri("https://v3.football.api-sports.io/"); // Set the base address
        _client.DefaultRequestHeaders.Add("x-rapidapi-key", "94cad5d0fdf6426e72bf730032dbced9"); // Add the API key
        _client.DefaultRequestHeaders.Add("x-rapidapi-host", "v3.football.api-sports.io");
    }

    public async Task<IActionResult> GetLeagues()
    {
        // Make the API call asynchronously
        var response = await _client.GetAsync("leagues");

        if (!response.IsSuccessStatusCode)
        {
            // Handle the case where the request was unsuccessful (e.g., logging or return an error view)
            return View("Error");
        }

        // Read the raw JSON content as a string
        string rawJson = await response.Content.ReadAsStringAsync();

        // Deserialize the raw JSON into the ApiResponse class
        var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(rawJson);

        // Ensure that leagues are available
        var leagueList = apiResponse?.Response?.SelectMany(r => r.Leagues).ToList() ?? new List<Season>(); // Safely access the leagues

        // Optionally, you can work with the data like below if needed (e.g., first league's details)
        if (leagueList.Any())
        {
            var leagueName = leagueList[0].Name;
            var countryName = apiResponse.Response[0].Country.Name;
            var seasons = apiResponse.Response[0].Seasons;
            // You can pass additional data to the view if needed
        }

        // Pass the league list to the view
        return View(leagueList);
    }
}
