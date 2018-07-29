using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAPI.Models.Shared;

namespace WeatherAPI.Models
{
    // forecast info
    public class ForecastInfo
    {
        // each 3 hour weather forecast info
        [JsonProperty("list")]
        public IEnumerable<ForecastElement> List;

        // city info
        [JsonProperty("city")]
        public City City { get; set; }
    }

    // 3 hour info
    public class ForecastElement
    {
        [JsonProperty("main")]
        public ForecastMainInfo Main { get; set; }

        [JsonProperty("clouds")]
        public Clouds Cloudiness { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("dt_txt")]
        public string Date { get; set; }
    }

    // temperature info
    public class ForecastMainInfo
    {
        // min temperature
        [JsonProperty("temp_min")]
        public double TempMin { get; set; }

        // max temperature
        [JsonProperty("temp_max")]
        public double TempMax { get; set; }
    }

    // city info
    public class City
    {
        // city name
        [JsonProperty("name")]
        public string CityName { get; set; }
    }
}
