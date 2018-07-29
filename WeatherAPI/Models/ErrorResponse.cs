using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Models
{
    // error info
    public class ErrorResponse
    {
        // response code
        [JsonProperty("cod")]
        public int ResponseCode { get; set; }

        // error message
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
