using System.Text.Json.Serialization;

namespace Projects.GitHub.Models
{
    public class GitHubRepoViewModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("full_name")]
        public string FullName { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
