using Microsoft.Maui.Devices.Sensors;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using OpenSkysDotNet.Models;
using System.Windows.Input;
using OpenSkysDotNet.Resources;

namespace OpenSkysDotNet.ViewModels;
public class HomeViewModel : INotifyPropertyChanged
{
    #region Properties
    private string _currentWeatherPhrase;
    public string CurrentWeatherPhrase { get => _currentWeatherPhrase; set { _currentWeatherPhrase = value; OnPropertyChanged(); } }
    private string _locationCityNameState;
    public string LocationCityNameState { get => _locationCityNameState; set { _locationCityNameState = value; OnPropertyChanged(); } }
    private string _weatherDescription;
    public string WeatherDescription { get => _weatherDescription; set { _weatherDescription = value; OnPropertyChanged(); } }
    private string _temperature;
    public String Temperature { get => _temperature; set { _temperature = value; OnPropertyChanged(); } }
    private double _windSpeed;
    private double _precipitationSum;
    public double PrecipitationSum { get => _precipitationSum; set { _precipitationSum = value; OnPropertyChanged(); } }
    public double WindSpeed { get => _windSpeed; set { _windSpeed = value; OnPropertyChanged(); } }
    private LocationData _locationData;
    public LocationData LocationData { get => _locationData; set { _locationData = value; OnPropertyChanged(); } }

    private List<Forecast> _week;
    public List<Forecast> Week { get => _week; set { _week = value; OnPropertyChanged(); } }
    private List<Forecast> _hours;
    public List<Forecast> Hours { get => _hours; set { _hours = value; OnPropertyChanged(); } }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion

    public HomeViewModel()
    {
        //InitData();
    }

    public async Task LoadWeatherDataAsync()
    {       
        WeatherData weatherData = await GeoMetWeatherService.Instance.GetWeatherDataAsync();
        LocationData locationData = await ReverseGeocodeService.Instance.GetLocationDataasync();

        await UpdateWeatherForecast(weatherData);

        LocationCityNameState = $"{locationData.Address.City + ", " + locationData.Address.State}";
        CurrentWeatherPhrase = PickImageFromData.GetImagePath(weatherData.Current.WeatherCode);
        WeatherDescription = PickImageFromData.GetWeatherDescription(weatherData.WeatherCode);
        Temperature = weatherData.Current.Temperature2m.ToString() + weatherData.CurrentUnits.Temperature2m.ToString();
        WindSpeed = weatherData.Current.WindSpeed10m;
    }


    public async Task<bool> UpdateWeatherForecast(WeatherData weatherData)
    {
        _hours = new List<Forecast>();
        for (int hour = 0; hour < 24; hour++)
        {
            DateTime currentHour = DateTime.Now.AddHours(hour + 1);
            Forecast newForecast = new Forecast
            {
                DateTime = currentHour,
                Day = new Day { Phrase = PickImageFromData.GetImagePath(weatherData.Hourly.WeatherCode[currentHour.Hour + hour]) },
                TemperatureMin = weatherData.Hourly.Temperature2m[currentHour.Hour + hour],
                TemperatureMax = weatherData.Hourly.Temperature2m[currentHour.Hour + hour]
            };

            _hours.Add(newForecast);
        }

        _week = new List<Forecast>();
        for (int day = 0; day < 7; day++)
        {
            Forecast newForecast = new Forecast
            {
                DateTime = DateTime.Now.AddDays(day),

                Day = new Day { Phrase = PickImageFromData.GetImagePath(weatherData.Daily.WeatherCode[day]) },
                TemperatureMin = Math.Floor(weatherData.Daily.Temperature2mMin[day]),
                TemperatureMax = Math.Ceiling(weatherData.Daily.Temperature2mMax[day]),
                PrecipitationSum = weatherData.Daily.PrecipitationSum[day]
            };

            _week.Add(newForecast);
        }

        OnPropertyChanged("Hours");
        OnPropertyChanged("Phrase");
        OnPropertyChanged("Day");
        OnPropertyChanged("Temperature");
        OnPropertyChanged("Week");
        return true;
    }
}
