using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Interfaces
{
    public interface IConfigurationService
    {
        string GetWeatherApiUrl(double latitude, double longitude);
    }
}
