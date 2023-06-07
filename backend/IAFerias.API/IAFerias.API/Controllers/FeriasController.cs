using IAFerias.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IAFerias.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeriasController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        public FeriasController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpPost]
        public async Task<ActionResult> Post(string lugar, int dias, [FromServices] IConfiguration config)
        {
            var gptKey = config.GetValue<string>("GptKey:ServiceApiKey"); 
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", gptKey);

            var model = new ChatGptRequest(lugar, dias);
            var requestBody = JsonSerializer.Serialize(model);
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://api.openai.com/v1/completions", content);
            var result = await response.Content.ReadFromJsonAsync<ChatGptResponse>();
            var prompt = result.choices.First();

            return Ok(prompt.text.Replace("\n", ""));
        }
    }
}
