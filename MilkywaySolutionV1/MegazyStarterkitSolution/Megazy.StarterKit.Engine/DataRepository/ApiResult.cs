using Newtonsoft.Json;

namespace Megazy.StarterKit.Engine.DataRepository
{
    public abstract class ApiResult
    {
        public string Status { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
    }
}