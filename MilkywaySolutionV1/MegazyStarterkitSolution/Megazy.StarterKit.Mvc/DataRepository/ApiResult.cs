using Newtonsoft.Json;

namespace Megazy.StarterKit.Mvc.DataRepository
{
    public abstract class ApiResult
    {
        public string Status { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
    }
}