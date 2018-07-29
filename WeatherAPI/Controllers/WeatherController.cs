using WeatherAPI.Interfaces;
using WeatherAPI.Models;
using WeatherAPI.Util;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        // weather data provider
        private IWeatherProvider weather = new WeatherProvider();

        /// <summary>
        /// Get current weather in specific city
        /// </summary>
        /// <param name="cityName">City name</param>
        /// <returns>Current weather in specific city</returns>
        /// <response code="404">Wrong city name</response>
        /// <response code="500">Internal Server Error</response>
        // GET api/weather/current/cityName
        [HttpGet("current/{cityName}", Name = "Current")]
        public ActionResult GetCurrentWeather(string cityName)
        {
            try
            {
                var result = weather.getCurrentWeather(cityName);           // get current weather
                Response.StatusCode = 200;                                  // set response code
                return Json(result);
            }
            catch (ServiceException ex)
            {
                Response.StatusCode = ex.ResponseCode;
                return Json(ex.Message);
            }
        }

        /// <summary>
        /// Get 5 day weather forecast in specific city
        /// </summary>
        /// <param name="cityName">City name</param>
        /// <returns>5 day weather forecast in specific city</returns>
        /// <response code="404">Wrong city name</response>
        /// <response code="500">Internal Server Error</response>
        // GET api/weather/forecast/cityName
        [HttpGet("forecast/{cityName}", Name = "Forecast")]
        public ActionResult GetForecast(string cityName)
        {
            try
            {
                var result = weather.getWeatherForecast(cityName);          // get 5 day weather forecast
                Response.StatusCode = 200;                                  // set response code
                return Json(result);
            }
            catch (ServiceException ex)
            {
                Response.StatusCode = ex.ResponseCode;
                return Json(ex.Message);
            }
        }
    }
}
