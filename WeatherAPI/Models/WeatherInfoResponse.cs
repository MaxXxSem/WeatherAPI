using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Models
{
    // simplified weather info class
    public class WeatherInfoResponse
    {
        public string CityName { get; set; }
        public string Date { get; set; }

        // current temperature
        public double Temperature { get; set; }

        // wind speed
        public double WindSpeed { get; set; }

        // cloudiness percentage
        public double CloudinessPercentage { get; set; }
    }
}
