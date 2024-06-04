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
    private string locationCityNameState;
    private string weatherDescription;
    private string temperature;
    private double windSpeed;

    private List<Forecast> week;
    private List<Forecast> hours;


    private LocationData locationData;


    public string LocationCityNameState
    {
        get => locationCityNameState;
        set
        {
            locationCityNameState = value;
            OnPropertyChanged();
        }
    }

    public string WeatherDescription
    {
        get => weatherDescription;
        set
        {
            weatherDescription = value;
            OnPropertyChanged();
        }
    }

    public String Temperature
    {
        get => temperature;
        set
        {
            temperature = value;
            OnPropertyChanged();
        }
    }

    public double WindSpeed
    {
        get => windSpeed;
        set
        {
            windSpeed = value;
            OnPropertyChanged();
        }
    }

    public LocationData LocationData
    {
        get => locationData;
        set
        {
            locationData = value;
            OnPropertyChanged();
        }
    }

    public List<Forecast> Week
    {
        get => week;
        set
        {
            week = value;
            OnPropertyChanged();
        }
    }

    public List<Forecast> Hours
    {
        get => hours;
        set
        {
            hours = value;
            OnPropertyChanged();
        }
    }

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
        WeatherDescription = PickImageFromData.GetWeatherDescription(weatherData.WeatherCode);
        Temperature = weatherData.Current.Temperature2m.ToString() + weatherData.CurrentUnits.Temperature2m.ToString();
        WindSpeed = weatherData.Current.WindSpeed10m;
    }
     

    public async Task<bool> UpdateWeatherForecast(WeatherData weatherData)
    {
        hours = new List<Forecast>();
        for (int i = 0; i < 24; i++)
        {
            Forecast newForecast = new Forecast
            {
                DateTime = DateTime.Now.AddHours(i + 1),
                Day = new Day { Phrase = PickImageFromData.GetWeatherDescription(weatherData.Hourly.WeatherCode[i]) },
                Temperature = new Temperature { Minimum = new Minimum { Unit = "C", Value = (int)weatherData.Hourly.Temperature2m[i] }, Maximum = new Maximum { Unit = "C", Value = (int)weatherData.Hourly.Temperature2m[i] } },
            };
            hours.Add(newForecast);
        }
/*        if (hours == null) { return; }
        for (int i = 0; i < hours.Count; i++)
        {
            hours[i].Temperature.Minimum.Value = (int)weatherData.Hourly.Temperature2m[i];
            Debug.Print("Temperature: " + weatherData.Hourly.Temperature2m[i]);
            hours[i].Temperature.Maximum.Value = (int)weatherData.Hourly.Temperature2m[i];
        }*/
        OnPropertyChanged("Hours");
        OnPropertyChanged("Temperature.Minimum.Value");
        OnPropertyChanged("Temperature");
        return true;
    }
}
