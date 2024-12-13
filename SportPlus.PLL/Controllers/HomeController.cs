using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SportPlus.PLL.Models;
using System.Diagnostics;

namespace SportPlus.PLL.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _client;

        // Constructor to inject HttpClient
        public HomeController(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://v3.football.api-sports.io/"); // Set the base address
            _client.DefaultRequestHeaders.Add("x-rapidapi-key", "94cad5d0fdf6426e72bf730032dbced9"); // Add the API key
            _client.DefaultRequestHeaders.Add("x-rapidapi-host", "v3.football.api-sports.io");
        }
        public async Task<IActionResult> Index()
        {
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
            return View(Fixtures);
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
        [HttpPost]
        public async Task<IActionResult> MatchStats(int id)
        {
            var response = await _client.GetAsync($"fixtures/statistics?&fixture={id}");

            if (!response.IsSuccessStatusCode)
            {
                // Handle the case where the request was unsuccessful (e.g., logging or return an error view)
                return View("Error");
            }
            // Read the raw JSON content as a string
            string rawJson = await response.Content.ReadAsStringAsync();

            //Deserialize the raw JSON into the ApiResponse class
            var MatchStats = JsonConvert.DeserializeObject<MatchResponse>(rawJson);
            return View(MatchStats);
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
