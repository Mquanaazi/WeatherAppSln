using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using WeatherApp.Interfaces;

namespace WeatherApp.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private const string ApiKey = "536d32af06a0fbe9a1b0ca1b3ec3691d";

        public string GetWeatherApiUrl(double latitude, double longitude)
        {
            string lat = latitude.ToString();
            string lon = longitude.ToString();

            return $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&units=metric&appid={ApiKey}";
        }
    }
}
            //WeatherApiUrl = "$https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={long}&appid=536d32af06a0fbe9a1b0ca1b3ec3691d";
