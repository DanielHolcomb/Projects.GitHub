using Core.HttpDynamo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projects.GitHub.Models;

namespace Projects.GitHub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GitHubController : ControllerBase
    {
        private readonly ILogger<GitHubController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public GitHubController(ILogger<GitHubController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("/repo/{org}/{repoName}")]
        [Authorize]
        public async Task<IActionResult> GetRepo(string org, string repoName)
        {
            var url = $"https://api.github.com/repos/{org}/{repoName}";
            var headers = new Dictionary<string, string>();
            headers.Add("User-Agent", "request");
            var result = await HttpDynamo.GetRequestAsync<GitHubRepo>(_httpClientFactory, url, headers);

            var githubrepo = new GitHubRepoViewModel()
            {
                Name = result.Name,
                FullName = result.FullName,
                Description = result.Description
            };

            return Ok(githubrepo);
        }
    }
}