using IAFerias.API.Interfaces;
using IAFerias.API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IAFerias.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeriasController : ControllerBase
    {
        private readonly IApiService _apiService;

        public FeriasController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Ferias ferias)
        {
            try
            {
                _apiService.AuthenticationKey();
                var content = _apiService.CreateStringContent(ferias);
                var response = await _apiService.SendRequestAsync(content);

                if (response.IsSuccessStatusCode)
                {
                    var prompt = await _apiService.GetPromptAsync(response);

                    return Ok(prompt.Replace("\n", "").Replace("\t", " "));

                }
                return BadRequest("Não foi possível fazer seu roteiro de férias.");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Não conseguimos acessar o seu roteiro de férias: " + e.Message);
            }
        }
    }
}
