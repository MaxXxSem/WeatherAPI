using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WeatherAPI.Controllers;

namespace Tests
{
    [TestClass]
    class WeatherControllerTest
    {
        [TestMethod]
        public void GetCurrentWeatherOK()
        {
            WeatherController cont = new WeatherController();
            var result = cont.GetCurrentWeather("dnipro");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetCurrentWeather404()
        {
            try
            {
                WeatherController cont = new WeatherController();
                var result = cont.GetCurrentWeather("d");
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);
            }
        }

        [TestMethod]
        public void GetForecastOK()
        {
            WeatherController cont = new WeatherController();
            var result = cont.GetForecast("dnipro");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetForecast404()
        {
            try
            {
                WeatherController cont = new WeatherController();
                var result = cont.GetForecast("d");
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);
            }
        }
    }
}
