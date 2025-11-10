using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

[Route("api/[controller]")]
[ApiController]
public class GabrielPostaController : ControllerBase
{
    public readonly HttpClient httpClient;

    public GabrielPostaController(HttpClient httpClient)
    {
        this.httpClient = httpClient;
        httpClient.BaseAddress = new Uri("");
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var respuesta = await httpClient.GetAsync("http://localhost:521/api/NachoPosta");
        if (respuesta.IsSuccessStatusCode)
        {
            var data = await respuesta.Content.ReadAsStringAsync();
            Console.WriteLine("Por aqui paso la posta de Gabriel");
        }

        return StatusCode((int)respuesta.StatusCode, "");
    }
}
