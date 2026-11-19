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
        private IConfigurationService _configurationService;
        private HttpClient _httpClient;

        public WeatherHttpApiService(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
            _httpClient = new HttpClient();
        }

        public async Task<Location> GetLocationAsync()
        {
            try
            {
                PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

                if (status != PermissionStatus.Granted)
                {
                    status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                }

                if (status != PermissionStatus.Granted)
                {
                    return null;
                }

                Location location = await Geolocation.Default.GetLastKnownLocationAsync();

                if (location == null)
                {
                    GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                    location = await Geolocation.Default.GetLocationAsync(request);
                }

                return location;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<WeatherData> GetWeatherDataAsync()
        {
            Location location = await GetLocationAsync();

            if (location == null)
            {
               
                return null;
            }

            string url = _configurationService.GetWeatherApiUrl(location.Latitude, location.Longitude);
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            string jsonContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<WeatherData>(jsonContent);
        }
    }
}