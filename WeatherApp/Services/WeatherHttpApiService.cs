using WeatherApp.Interfaces;
using WeatherApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WeatherApp.Services
{
    public class WeatherHttpApiService : IWeatherHttpApiService
    {
        private  IConfigurationService _configurationService;
        private HttpClient _httpClient;
        public WeatherHttpApiService(IConfigurationService configurationService)
        {
            _configurationService = configurationService;

            _httpClient = new HttpClient();

        }
        public async Task<string> GetWeatherDataAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_configurationService.WeatherApiUrl);
            //return _httpClient.GetStringAsync(_configurationService.WeatherApiUrl).Result;

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
              WeatherData weatherData = JsonSerializer.Deserialize<WeatherData>(jsonContent);


                if (weatherData != null)
                {
                    return weatherData.temp.ToString();
                }
                else
                {
                    return "No weather data found.";
                }
            }
            return null;
        }
    }
}
