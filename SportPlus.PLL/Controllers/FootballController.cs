using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using SportPlus.PLL.Models;
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

    //public async Task<IActionResult> GetFixtures()
    //{
    //    //Make the API call asynchronously
    //    //DateTime date = DateTime.Now;
    //    //date.ToString("yyyy-MM-dd");
    //    //Console.WriteLine(date);
    //    var response = await _client.GetAsync($"fixtures?&date=2024-12-01");

    //    if (!response.IsSuccessStatusCode)
    //    {
    //        // Handle the case where the request was unsuccessful (e.g., logging or return an error view)
    //        return View("Error");
    //    }

    //    // Read the raw JSON content as a string
    //    string rawJson = await response.Content.ReadAsStringAsync();

        // Deserialize the raw JSON into the ApiResponse class
        var Fixtures = JsonConvert.DeserializeObject<Fixtures>(rawJson);

        // Pass the league list to the view
        return View(Fixtures);
    }
}
