using WeatherApp.Interfaces;
using WeatherApp.Models;


namespace WeatherApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private IWeatherHttpApiService _weatherService;
        private WeatherData _weather;


        public HomeViewModel(IWeatherHttpApiService weatherService)
        {
            _weatherService = weatherService;
        }

        public WeatherData Weather
        {
            get { return _weather; }
            set
            {
                _weather = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Sunrise));
                OnPropertyChanged(nameof(Sunset));
            }
        }

        public string Sunrise
        {
            get
            {
                if (Weather == null) return "";
                return DateTimeOffset.FromUnixTimeSeconds(Weather.sys.sunrise).ToLocalTime().ToString("HH:mm");
            }
        }

        public string Sunset
        {
            get
            {
                if (Weather == null) return "";
                return DateTimeOffset.FromUnixTimeSeconds(Weather.sys.sunset).ToLocalTime().ToString("HH:mm");
            }
        }

        public async Task LoadWeatherAsync()
        {
            Weather = await _weatherService.GetWeatherDataAsync();
        }


    }
}