using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Interfaces
{
    internal interface IMauiPopupService
    {
        Task ShowingPopUp(string title, string message, string buttonText);
    }
}
