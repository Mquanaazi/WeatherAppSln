namespace WeatherApp.Interfaces
{
    public interface WeatherHttpApiService
    {
        Task<string> GetWeatherDataAsync();
    }
}