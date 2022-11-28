using Microsoft.AspNetCore.Mvc;

namespace Projects.GitHub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GitHubController : ControllerBase
    {
        private readonly ILogger<GitHubController> _logger;

        public GitHubController(ILogger<GitHubController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}