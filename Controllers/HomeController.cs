using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AzureAPI.Controllers;

[ApiController]
[Route("/")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private IWebHostEnvironment _environment;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWebHostEnvironment environment)
    {
        _environment = environment;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var result = new
        {
            titulo = "Página do web app",
            ambiente = _environment.EnvironmentName,
            status = "Running"
        };

        var resultJson = JsonConvert.SerializeObject(result);
        var html = $"<p style='font-family: arial'>{resultJson}</p>";

        return Content(html, "text/html", Encoding.UTF8);
    }
}
