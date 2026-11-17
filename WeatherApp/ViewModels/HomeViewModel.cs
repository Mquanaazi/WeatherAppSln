using WeatherApp.ViewModels;
using WeatherApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WeatherApp.ViewModels
{
       public class HomeViewModel : BaseViewModel
        {

            private string _weatherData;
            public ICommand GetWeatherCommand { get; }
            public string WeatherData
            {
                get { return _weatherData; }
                set
                {
                    _weatherData = value;
                    OnPropertyChanged();
                }
            }

            private IWeatherHttpApiService _weatherApiService;
            public HomeViewModel(IWeatherHttpApiService service)
            {
                _weatherApiService = service;
                GetWeatherCommand = new Command(FetchWeather);
            }
            private async void FetchWeather(object param)
            {
                WeatherData = await _weatherApiService.GetWeatherDataAsync();
            }
        }

}                           
  
