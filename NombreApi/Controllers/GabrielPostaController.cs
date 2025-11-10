using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace TerminoDeBusqueda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GabrielPosta : ControllerBase
    {
        public readonly HttpClient _httpClient;
        public GabrielPosta(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]

        public async Task<IActionResult> get()
        {
            var response = await _httpClient.GetAsync("https://localhost:numero/api/FernadnoPosta");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Por aca paso la posta de Gabriel");
                return Ok(content);
            }
            else
            {
                return StatusCode((int)response.StatusCode, "Error al llamar a Fernando");
            }

        }

    }
}