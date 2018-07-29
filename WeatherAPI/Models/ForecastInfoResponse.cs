using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Models
{
    // simplified forecast info class
    public class ForecastInfoResponse
    {
        // each 3 hour forecast
        public ICollection<ForecastElementResponse> List;

        // city name
        public string CityName { get; set; }
    }

    // 3 hour weather info
    public class ForecastElementResponse
    {
        // min temperature
        public double TempMin { get; set; }

        // max temperature
        public double TempMax { get; set; }

        // forecast date
        public string Date { get; set; }

        // wind speed
        public double WindSpeed { get; set; }

        // cloudiness percentage
        public double CloudinessPercentage { get; set; }
    }
}
