using Microsoft.Maui.Devices.Sensors;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Weather__.ViewModels;
public class HomeViewModel : INotifyPropertyChanged
{
    private string weatherDescription;
    private string temperature;
    private double windSpeed;

    private double latitude;
    private double longitude;

    private string cityName;
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

    public double Latitude
    {
        get => latitude;
        set
        {
            latitude = value;
            OnPropertyChanged();
        }
    }

    public double Longitude
    {
        get => longitude;
        set
        {
            longitude = value;
            OnPropertyChanged();
        }
    }
    public string CityName
    {
        get => cityName;
        set
        {
            cityName = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public async Task LoadWeatherDataAsync()
    {
        await GetLocationAsync();
        await GetCityNameAsync();

        GeoMetWeatherService weatherService = new GeoMetWeatherService();
        string endpoint = "https://api.open-meteo.com/v1/forecast?latitude=" + Latitude + "&longitude=" + Longitude + "&current=temperature_2m,wind_speed_10m&hourly=temperature_2m,relative_humidity_2m,wind_speed_10m";
        WeatherData weatherData = await weatherService.GetWeatherDataAsync(endpoint);

        WeatherDescription = $"Current weather in {CityName}:";
        Temperature = weatherData.Current.Temperature2m.ToString() + weatherData.CurrentUnits.Temperature2m.ToString();
        WindSpeed = weatherData.Current.WindSpeed10m;
    }
     
    public async Task GetLocationAsync()
    {
        try
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
            var location = await Geolocation.GetLocationAsync(request);

            if (location != null)
            {
                Latitude = location.Latitude;
                Longitude = location.Longitude;
            }
        }
        catch (FeatureNotSupportedException fnsEx)
        {
            // Handle not supported on device exception
        }
        catch (FeatureNotEnabledException fneEx)
        {
            // Handle not enabled on device exception
        }
        catch (PermissionException pEx)
        {
            // Handle permission exception
        }
        catch (Exception ex)
        {
            // Unable to get location
        }
    }

    public async Task GetCityNameAsync()
    {
        ReverseGeocodeService reverseGeocodeService = new ReverseGeocodeService();
        CityName = await reverseGeocodeService.GetCityNameAsync(Latitude, Longitude);
    }
}
