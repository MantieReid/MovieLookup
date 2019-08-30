using Newtonsoft.Json;

namespace MovieLookup.Core.Models
{
    public class ErrorResponse
    {
        [JsonProperty("status_message")]
        public string StatusMessage { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("status_code")]
        public long StatusCode { get; set; }
    }
}
