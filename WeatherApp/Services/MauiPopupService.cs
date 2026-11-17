using WeatherApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Services
{
    internal class MauiPopupService : IMauiPopupService
    {
        public async Task ShowingPopUp(string title, string message, string buttonText)
        {
           await Shell.Current.DisplayAlertAsync(title,message, buttonText);
           
        }
    }
}
