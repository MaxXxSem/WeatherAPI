using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAPI.Models.Shared;

namespace WeatherAPI.Models
{
    // current weather info
    public class WeatherInfo
    {
        public WeatherInfo()
        {
            Date = DateTime.Now.ToString("s");
        }

        [JsonProperty("main")]
        public MainInfo Main { get; set; }

        [JsonProperty("wind")]
        public Wind Wind{ get; set; }

        [JsonProperty("clouds")]
        public Clouds Cloudiness { get; set; }

        [JsonProperty("name")]
        public string CityName { get; set; }

        public string Date { get; set; }
    }

    // temperature info
    public class MainInfo
    {
        // current weather temperature
        [JsonProperty("temp")]
        public double Temperature { get; set; }
    }
}
