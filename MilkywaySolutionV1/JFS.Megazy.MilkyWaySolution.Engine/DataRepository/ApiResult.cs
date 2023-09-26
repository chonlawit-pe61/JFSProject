using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public abstract class ApiResult
    {
        public string Status { get; set; }
        public int StatusCode { get; set; }
        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
    }
}
