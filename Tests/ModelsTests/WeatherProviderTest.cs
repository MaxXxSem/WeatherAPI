using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherAPI.Models;
using WeatherAPI.Controllers;
using System;

namespace Tests
{
    [TestClass]
    public class WeatherProviderTest
    {
        [TestMethod]
        public void CurrentWeatherOK()
        {
            var result = new WeatherProvider().getCurrentWeather("dnipro");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CurrentWeather404()
        {
            try
            {
                var result = new WeatherProvider().getCurrentWeather("d");
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);
            }
        }

        [TestMethod]
        public void ForecastOK()
        {
            var result = new WeatherProvider().getWeatherForecast("dnipro");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Forecast404()
        {
            try
            {
                var result = new WeatherProvider().getWeatherForecast("d");
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);
            }
        }
    }
}
