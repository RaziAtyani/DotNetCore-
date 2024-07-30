using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;


namespace TASK1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public FootballController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        // Get Method 
        [HttpGet("teams")]
        public async Task<IActionResult> GetTeams()
        {
            var response = await _httpClient.GetStringAsync("https://my-json-server.typicode.com/RaziAtyani/FootballJSON/teams");
            return Content(response, "application/json");
        }
        //Post Method

        [HttpGet("teams/{id}")]
        public async Task<IActionResult> GetTeam(int id)
        {
            var response = await _httpClient.GetStringAsync($"https://my-json-server.typicode.com/RaziAtyani/FootballJSON/teams/{id}");
            return Content(response, "application/json");
        }
        //Get Method
        [HttpPost("teams")]
        public async Task<IActionResult> CreateTeam([FromBody] object team)
        {
            var content = new StringContent(team.ToString(), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://my-json-server.typicode.com/RaziAtyani/FootballJSON/teams", content);
            var responseBody = await response.Content.ReadAsStringAsync();
            return Content(responseBody, "application/json");
        }

        [HttpPut("teams/{id}")]
        public async Task<IActionResult> UpdateTeam(int id, [FromBody] object team)
        {
            var content = new StringContent(team.ToString(), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"https://my-json-server.typicode.com/RaziAtyani/FootballJSON/teams/{id}", content);
            var responseBody = await response.Content.ReadAsStringAsync();
            return Content(responseBody, "application/json");
        }

        [HttpDelete("teams/{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://my-json-server.typicode.com/RaziAtyani/FootballJSON/teams/{id}");
            var responseBody = response.IsSuccessStatusCode ? "Deleted successfully" : "Error deleting team";
            return Content(responseBody, "application/json");
        }

        [HttpGet("players")]
        public async Task<IActionResult> GetPlayers()
        {
            var response = await _httpClient.GetStringAsync("https://my-json-server.typicode.com/RaziAtyani/FootballJSON/players");
            return Content(response, "application/json");
        }
    }
}
