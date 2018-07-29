using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Models.Shared
{
    // wind info
    public class Wind
    {
        // wind speed
        [JsonProperty("speed")]
        public double WindSpeed { get; set; }
    }

    // clouds info
    public class Clouds
    {
        // cloudiness percentage
        [JsonProperty("all")]
        public double CloudinessPercentage { get; set; }
    }
}
