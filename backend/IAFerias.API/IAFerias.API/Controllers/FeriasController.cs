using Microsoft.AspNetCore.Mvc;
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
    }
}
