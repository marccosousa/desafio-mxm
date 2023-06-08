using AutoMapper;
using IAFerias.API.Models;
using IAFerias.API.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Runtime.Intrinsics.X86;
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
        private readonly IMapper _mapper;
        public FeriasController(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Ferias ferias, [FromServices] IConfiguration config)
        {
            var gptKey = config.GetValue<string>("GptKey:ServiceApiKey");
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", gptKey);

            var model = new ChatGptRequest(ferias);
            var requestBody = JsonSerializer.Serialize(model);
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://api.openai.com/v1/completions", content);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ChatGptResponse>();
                var resultDTO = _mapper.Map<GptResponseDTO>(result);
                var prompt = resultDTO?.Choice?.Text;

                if (!string.IsNullOrEmpty(prompt))
                {
                    return Ok(prompt.Replace("\n", ""));
                }
            }
            return BadRequest("Não foi possível fazer seu roteiro de férias.");

        }
    }
}
