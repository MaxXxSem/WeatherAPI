using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAPI.Models;

namespace WeatherAPI.Interfaces
{
    interface IWeatherProvider
    {
        // get current weather in specific city
        WeatherInfoResponse getCurrentWeather(string cityName);

        // get 5 day forecast in specific city
        ForecastInfoResponse getWeatherForecast(string cityName);
    }
}
