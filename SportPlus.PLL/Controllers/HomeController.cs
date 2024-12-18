using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SportPlus.PLL.Models;
using System.Diagnostics;
using SportPlus.BLL.ModelVM;
using Microsoft.AspNetCore.Identity;
using SportPlus.BLL.Service.Abstraction;
using SportPlus.DAL.Entities;
using System.Configuration;
using SportPlus.DAL.Enums;
using System.Collections.Generic;

namespace SportPlus.PLL.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _client;
        private readonly UserManager<User> _userManager;

        // Constructor to inject HttpClient
        public HomeController(HttpClient client , UserManager<User> userManager)
        {
            _userManager = userManager;
            _client = client;
            _client.BaseAddress = new Uri("https://v3.football.api-sports.io/"); // Set the base address
            _client.DefaultRequestHeaders.Add("x-rapidapi-key", "747785eed51ceb8aef6e0bfc8f8572b8"); // Add the API key
            _client.DefaultRequestHeaders.Add("x-rapidapi-host", "v3.football.api-sports.io");
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            //if (user == null)
            //{
            //    return View("Error");
            //}

            // Get the user's favorite team
            var favoriteTeam = user?.FavouriteTeam;
            //Make the API call asynchronously
            DateTime date = DateTime.Now;
            string formattedDate = date.ToString("yyyy-MM-dd");
            var response = await _client.GetAsync($"fixtures?&date={formattedDate}");

            if (!response.IsSuccessStatusCode)
            {
                // Handle the case where the request was unsuccessful (e.g., logging or return an error view)
                return View("Error");
            }
            // Read the raw JSON content as a string
            string rawJson = await response.Content.ReadAsStringAsync();

            //Deserialize the raw JSON into the ApiResponse class
            var Fixtures = JsonConvert.DeserializeObject<FixtureResponse>(rawJson);
            var model = Tuple.Create(Fixtures, favoriteTeam);
            return View(model);
        }
        public async Task<IActionResult> Standing()
        {
            var teamInput = new teamInput();  // Input form data
            return View(teamInput);
        }
        public async Task<IActionResult> Standings(teamInput LeagueInput)
        {
            var leagueId = (int)LeagueInput.League.GetValueOrDefault();
            var response1 = await _client.GetAsync($"standings?league={leagueId}&season={LeagueInput.Season}");
            var response2 = await _client.GetAsync($"players/topscorers?league={leagueId}&season={LeagueInput.Season}");
            var response3 = await _client.GetAsync($"players/topassists?league={leagueId}&season={LeagueInput.Season}");
            
            string rawJson_standing = await response1.Content.ReadAsStringAsync();
            string rawJson_scorers = await response2.Content.ReadAsStringAsync();
            string rawJson_assists = await response3.Content.ReadAsStringAsync();

            if (!response1.IsSuccessStatusCode && !response2.IsSuccessStatusCode && !response3.IsSuccessStatusCode)
            {
                // Handle the case where the request was unsuccessful (e.g., logging or return an error view)
                return View("Error");
            }

            var standing = JsonConvert.DeserializeObject<StandingRoot>(rawJson_standing);
            var scorers = JsonConvert.DeserializeObject<TopScorerRoot>(rawJson_scorers);
            var assisters = JsonConvert.DeserializeObject<TopScorerRoot>(rawJson_assists);
            var model = Tuple.Create(standing, scorers, assisters);
            return View(model);
        }
        public async Task<IActionResult> MatchStats(int id)
        {
            var response = await _client.GetAsync($"fixtures/statistics?&fixture={id}");
            var response2 = await _client.GetAsync($"fixtures/lineups?&fixture={id}");
            if (!response.IsSuccessStatusCode || !response2.IsSuccessStatusCode) return View("Error");
            string rawJson = await response.Content.ReadAsStringAsync();
            string rawJson2 = await response2.Content.ReadAsStringAsync();
            var matchStatistics = JsonConvert.DeserializeObject<MatchRoot>(rawJson);
            var lineup = JsonConvert.DeserializeObject<LineupRoot>(rawJson2);
            if (matchStatistics == null || matchStatistics.Response == null) return View("Error");
            foreach (var teamData in matchStatistics.Response)
            {
                // Process raw statistics
                var ProcessedStatistics = MatchStatisticsMapper.MapStatistics(teamData.Statistics);
                teamData.FormattedStatistics = ProcessedStatistics;
            }
            var model = Tuple.Create(matchStatistics, lineup);
            return View(model);
        }
        [HttpGet]
        public IActionResult TeamStatistics()
        {
            // Initialize teamInput and TeamRoot models
            var teamInput = new teamInput();  // Input form data
            return View(teamInput);
        }
        public async Task<IActionResult> TeamStats(teamInput teamInput)
        {
            var leagueId = (int)teamInput.League.GetValueOrDefault();
            var teamId = (int)teamInput.Team.GetValueOrDefault();
            // Call API to fetch team statistics
            var response = await _client.GetAsync($"teams/statistics?league={leagueId}&season={teamInput.Season}&team={teamId}");

            if (!response.IsSuccessStatusCode)
            {
                // Handle error (e.g., log or return error view)
                return View("Error");
            }

            // Deserialize the raw JSON content
            string rawJson = await response.Content.ReadAsStringAsync();
            var TeamStats = JsonConvert.DeserializeObject<TeamRoot>(rawJson);
            return View(TeamStats);
        }

    }
}
