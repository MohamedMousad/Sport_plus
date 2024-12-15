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
            _client.DefaultRequestHeaders.Add("x-rapidapi-key", "94cad5d0fdf6426e72bf730032dbced9"); // Add the API key
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
        public async Task<IActionResult> Standings()
        {
            var leagues = new[] { 39, 140, 135, 78, 61, 88 }; // Enum values for the leagues
            var tasks = leagues.Select(league => _client.GetAsync($"standings?league={league}&season=2021")).ToArray();
            var responses = await Task.WhenAll(tasks);

            foreach (var response in responses)
            {
                if (!response.IsSuccessStatusCode)
                {
                    // Handle the case where the request was unsuccessful (e.g., logging or return an error view)
                    return View("Error");
                }
            }

            var standings = new List<StandingRoot>();
            foreach (var response in responses)
            {
                // Read the raw JSON content as a string
                string rawJson = await response.Content.ReadAsStringAsync();
                // Deserialize the raw JSON into the ApiResponse class
                var standing = JsonConvert.DeserializeObject<StandingRoot>(rawJson);
                standings.Add(standing);
            }
            return View(standings);
        }
        public async Task<IActionResult> MatchStats(int id)
        {
            var response = await _client.GetAsync($"fixtures/statistics?&fixture={id}");
            if (!response.IsSuccessStatusCode) return View("Error");
            string rawJson = await response.Content.ReadAsStringAsync();
            var matchStatistics = JsonConvert.DeserializeObject<MatchRoot>(rawJson);
            if (matchStatistics == null || matchStatistics.Response == null) return View("Error");
            foreach (var teamData in matchStatistics.Response)
            {
                // Process raw statistics
                var ProcessedStatistics = MatchStatisticsMapper.MapStatistics(teamData.Statistics);
                teamData.FormattedStatistics = ProcessedStatistics;
            }
            return View(matchStatistics);
        }
        [HttpGet]
        public async Task<IActionResult> TeamStatistics()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> TeamStatistics(int team , int season , int league)
        {
            var response = await _client.GetAsync($"teams/statistics?&league={league}&season={season}&team={team}");

            if (!response.IsSuccessStatusCode)
            {
                // Handle the case where the request was unsuccessful (e.g., logging or return an error view)
                return View("Error");
            }
            // Read the raw JSON content as a string
            string rawJson = await response.Content.ReadAsStringAsync();

            //Deserialize the raw JSON into the ApiResponse class
            var TeamStats = JsonConvert.DeserializeObject<TeamRoot>(value: rawJson);
            return View(TeamStats);
        }
    }
}
