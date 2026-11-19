using WeatherApp.ViewModels;

namespace WeatherApp.Views;

public partial class HomePage : ContentPage
{

    private HomeViewModel _viewModel;

    public HomePage(HomeViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadWeatherAsync();
    }
}