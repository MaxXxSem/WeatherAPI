using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WeatherAPI.Interfaces;
using WeatherAPI.Util;

namespace WeatherAPI.Models
{
    public class WeatherProvider : IWeatherProvider
    {
        // current weather api address
        private const string currentWeatherAddress = "http://api.openweathermap.org/data/2.5/weather?units=metric&APPID=e59a5a33f2f92a7f49d12fb091618b3f&q=";       // APPID - private key, units - unit of measure

        // weather forecast api address
        private const string forecastAddress = "http://api.openweathermap.org/data/2.5/forecast?units=metric&APPID=e59a5a33f2f92a7f49d12fb091618b3f&q=";

        // get current weather for certain city
        public WeatherInfoResponse getCurrentWeather(string cityName)
        {
            try
            {
                WebClient client = new WebClient();
                string response = client.DownloadString(currentWeatherAddress + cityName);          // download json data
                WeatherInfo wInfo = JsonConvert.DeserializeObject<WeatherInfo>(response);           // deserialize json data

                WeatherInfoResponse returnObject = new WeatherInfoResponse()                        // set data to simplified object
                {
                    CityName = wInfo.CityName,
                    CloudinessPercentage = wInfo.Cloudiness.CloudinessPercentage,
                    Date = wInfo.Date,
                    Temperature = wInfo.Main.Temperature,
                    WindSpeed = wInfo.Wind.WindSpeed
                };

                return returnObject;
            }
            catch (WebException ex)
            {
                ErrorResponse error = ReadError(ex);                                                // read error stream
                throw new ServiceException(error.ResponseCode, error.Message);
            }
            catch (Exception ex)
            {
                throw new ServiceException(500, ex.Message);                                        // throw internal server error
            }
        }

        // get 5 day forecast for certain city
        public ForecastInfoResponse getWeatherForecast(string cityName)
        {
            try
            {
                WebClient client = new WebClient();
                string response = client.DownloadString(forecastAddress + cityName);                // download json data
                ForecastInfo fInfo = JsonConvert.DeserializeObject<ForecastInfo>(response);

                ForecastInfoResponse returnObject = new ForecastInfoResponse()                      // set data to simplified object
                {
                    CityName = fInfo.City.CityName,
                    List = new List<ForecastElementResponse>()
                };

                foreach (var item in fInfo.List)                                   // set each 3 hour forecast to simplified object
                {
                    returnObject.List.Add(new ForecastElementResponse()
                    {
                        TempMin = item.Main.TempMin,
                        TempMax = item.Main.TempMax,
                        CloudinessPercentage = item.Cloudiness.CloudinessPercentage,
                        WindSpeed = item.Wind.WindSpeed,
                        Date = DateTime.Parse(item.Date).ToString("s")
                    });
                }

                return returnObject;
            }
            catch (WebException ex)
            {
                ErrorResponse error = ReadError(ex);                                // read error stream
                throw new ServiceException(error.ResponseCode, error.Message);
            }
            catch (Exception ex)
            {
                throw new ServiceException(500, ex.Message);                        // throw internal server error
            }
        }

        // Read error response
        private ErrorResponse ReadError(WebException ex)
        {
            ErrorResponse error;
            using (Stream errorResponseStream = ex.Response.GetResponseStream())
            {
                using (StreamReader errorReadStream = new StreamReader(errorResponseStream))
                {
                    var errorResponse = errorReadStream.ReadToEnd();
                    error = JsonConvert.DeserializeObject<ErrorResponse>(errorResponse);        // deserialize error object
                }
            }

            return error;
        }
    }
}
