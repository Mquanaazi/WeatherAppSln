using WeatherApp.Models;

namespace WeatherApp.Interfaces
{
    public interface IWeatherHttpApiService
    {
        Task<WeatherData> GetWeatherDataAsync();
        Task<Location> GetLocationAsync();
    }
}