using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using SportPlus.PLL.Models;
public class Away
{
    public int id { get; set; }
    public string name { get; set; }
    public string logo { get; set; }
    public bool winner { get; set; }
}

public class Extratime
{
    public object home { get; set; }
    public object away { get; set; }
}

public class Fixture
{
    public int id { get; set; }
    public object referee { get; set; }
    public string timezone { get; set; }
    public DateTime date { get; set; }
    public int timestamp { get; set; }
    public Periods periods { get; set; }
    public Venue venue { get; set; }
    public Status status { get; set; }
}

public class Fulltime
{
    public object home { get; set; }
    public object away { get; set; }
}

public class Goals
{
    public int home { get; set; }
    public int away { get; set; }
}

public class Halftime
{
    public int home { get; set; }
    public int away { get; set; }
}

public class Home
{
    public int id { get; set; }
    public string name { get; set; }
    public string logo { get; set; }
    public bool winner { get; set; }
}

public class League
{
    public int id { get; set; }
    public string name { get; set; }
    public string country { get; set; }
    public string logo { get; set; }
    public string flag { get; set; }
    public int season { get; set; }
    public string round { get; set; }
}

public class Paging
{
    public int current { get; set; }
    public int total { get; set; }
}

public class Parameters
{
    public string live { get; set; }
}

public class Penalty
{
    public object home { get; set; }
    public object away { get; set; }
}

public class Periods
{
    public int first { get; set; }
    public object second { get; set; }
}

public class Response
{
    public Fixture fixture { get; set; }
    public League league { get; set; }
    public Teams teams { get; set; }
    public Goals goals { get; set; }
    public Score score { get; set; }
}

public class Root
{
    public string get { get; set; }
    public Parameters parameters { get; set; }
    public List<object> errors { get; set; }
    public int results { get; set; }
    public Paging paging { get; set; }
    public List<Response> response { get; set; }
}

public class Score
{
    public Halftime halftime { get; set; }
    public Fulltime fulltime { get; set; }
    public Extratime extratime { get; set; }
    public Penalty penalty { get; set; }
}

public class Status
{
    public string @long { get; set; }
    public string @short { get; set; }
    public int elapsed { get; set; }
    public object extra { get; set; }
}

public class Teams
{
    public Home home { get; set; }
    public Away away { get; set; }
}

public class Venue
{
    public int id { get; set; }
    public string name { get; set; }
    public string city { get; set; }
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

    public async Task<IActionResult> GetFixtures()
    {
        // Make the API call asynchronously
        DateTime date = DateTime.Now;
        date.ToString("MM-dd");
        Console.WriteLine(date);
        var response = await _client.GetAsync($"fixtures?season=2022&date=2022-{date}");

        if (!response.IsSuccessStatusCode)
        {
            // Handle the case where the request was unsuccessful (e.g., logging or return an error view)
            return View("Error");
        }

        // Read the raw JSON content as a string
        string rawJson = await response.Content.ReadAsStringAsync();

        // Deserialize the raw JSON into the ApiResponse class
        var Root = JsonConvert.DeserializeObject<Root>(rawJson);

        // Pass the league list to the view
        return View(Root);
    }
}
