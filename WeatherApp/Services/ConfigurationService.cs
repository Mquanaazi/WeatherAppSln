using WeatherApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Services
{
    public class ConfigurationService : IConfigurationService
    {
      public string WeatherApiUrl { get; }

   
        public ConfigurationService()
        {
            WeatherApiUrl = "https://api.openweathermap.org/data/2.5/weather?lat=-33.92838&lon=18.63363&appid=536d32af06a0fbe9a1b0ca1b3ec3691d";
            //WeatherApiUrl = "$https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={long}&appid=536d32af06a0fbe9a1b0ca1b3ec3691d";
        }
    }
}
