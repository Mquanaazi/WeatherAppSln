namespace WeatherApp.Interfaces
{
    public interface IWeatherHttpApiService
    {
        Task<string> GetWeatherDataAsync();
    }
}