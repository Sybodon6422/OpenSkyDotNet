﻿using Microsoft.Maui.Devices.Sensors;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Weather__.Models;

namespace Weather__.ViewModels;
public class HomeViewModel : INotifyPropertyChanged
{
    #region Properties
    private string weatherDescription;
    private string temperature;
    private double windSpeed;

    private double latitude;
    private double longitude;

    public List<Forecast> Week { get; set; }
    public List<Forecast> Hours { get; set; }


    private LocationData locationData;
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
    public LocationData LocationData
    {
        get => locationData;
        set
        {
            locationData = value;
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
        InitData();
    }

    private void InitData()
    {
        Week = new List<Forecast>
            {
                new Forecast
                {
                    DateTime = DateTime.Today.AddDays(1),
                    Day = new Day{ Phrase = "fluent_weather_sunny_high_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 52 }, Maximum = new Maximum { Unit = "F", Value = 77 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Today.AddDays(2),
                    Day = new Day{ Phrase = "fluent_weather_partly_cloudy" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 61 }, Maximum = new Maximum { Unit = "F", Value = 82 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Today.AddDays(3),
                    Day = new Day{ Phrase = "fluent_weather_rain_showers_day_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 62 }, Maximum = new Maximum { Unit = "F", Value = 77 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Today.AddDays(4),
                    Day = new Day{ Phrase = "fluent_weather_thunderstorm_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 57 }, Maximum = new Maximum { Unit = "F", Value = 80 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Today.AddDays(5),
                    Day = new Day{ Phrase = "fluent_weather_thunderstorm_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 49 }, Maximum = new Maximum { Unit = "F", Value = 61 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Today.AddDays(6),
                    Day = new Day{ Phrase = "fluent_weather_partly_cloudy" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 49 }, Maximum = new Maximum { Unit = "F", Value = 68 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Today.AddDays(7),
                    Day = new Day{ Phrase = "fluent_weather_rain_showers_day_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 47 }, Maximum = new Maximum { Unit = "F", Value = 67 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Today.AddDays(1),
                    Day = new Day{ Phrase = "fluent_weather_sunny_high_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 52 }, Maximum = new Maximum { Unit = "F", Value = 77 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Today.AddDays(2),
                    Day = new Day{ Phrase = "fluent_weather_partly_cloudy" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 61 }, Maximum = new Maximum { Unit = "F", Value = 82 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Today.AddDays(3),
                    Day = new Day{ Phrase = "fluent_weather_rain_showers_day_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 62 }, Maximum = new Maximum { Unit = "F", Value = 77 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Today.AddDays(4),
                    Day = new Day{ Phrase = "fluent_weather_thunderstorm_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 57 }, Maximum = new Maximum { Unit = "F", Value = 80 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Today.AddDays(5),
                    Day = new Day{ Phrase = "fluent_weather_thunderstorm_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 49 }, Maximum = new Maximum { Unit = "F", Value = 61 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Today.AddDays(6),
                    Day = new Day{ Phrase = "fluent_weather_partly_cloudy" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 49 }, Maximum = new Maximum { Unit = "F", Value = 68 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Today.AddDays(7),
                    Day = new Day{ Phrase = "fluent_weather_rain_showers_day_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 47 }, Maximum = new Maximum { Unit = "F", Value = 67 } },
                }
            };

        Hours = new List<Forecast>
            {
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(1),
                    Day = new Day{ Phrase = "fluent_weather_rain_showers_day_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 47 }, Maximum = new Maximum { Unit = "F", Value = 67 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(2),
                    Day = new Day{ Phrase = "fluent_weather_rain_showers_day_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 47 }, Maximum = new Maximum { Unit = "F", Value = 67 } },
                }
                ,
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(3),
                    Day = new Day{ Phrase = "fluent_weather_rain_showers_day_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 48 }, Maximum = new Maximum { Unit = "F", Value = 67 } },
                }
                ,
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(4),
                    Day = new Day{ Phrase = "fluent_weather_rain_showers_day_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 49 }, Maximum = new Maximum { Unit = "F", Value = 67 } },
                }
                ,
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(5),
                    Day = new Day{ Phrase = "fluent_weather_cloudy_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 52 }, Maximum = new Maximum { Unit = "F", Value = 67 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(6),
                    Day = new Day{ Phrase = "fluent_weather_cloudy_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 53 }, Maximum = new Maximum { Unit = "F", Value = 67 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(7),
                    Day = new Day{ Phrase = "fluent_weather_cloudy_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 58 }, Maximum = new Maximum { Unit = "F", Value = 67 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(8),
                    Day = new Day{ Phrase = "fluent_weather_sunny_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 63 }, Maximum = new Maximum { Unit = "F", Value = 67 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(9),
                    Day = new Day{ Phrase = "fluent_weather_sunny_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 64 }, Maximum = new Maximum { Unit = "F", Value = 67 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(10),
                    Day = new Day{ Phrase = "fluent_weather_sunny_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 65 }, Maximum = new Maximum { Unit = "F", Value = 67 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(11),
                    Day = new Day{ Phrase = "fluent_weather_sunny_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 68 }, Maximum = new Maximum { Unit = "F", Value = 67 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(12),
                    Day = new Day{ Phrase = "fluent_weather_sunny_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 68 }, Maximum = new Maximum { Unit = "F", Value = 67 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(13),
                    Day = new Day{ Phrase = "fluent_weather_sunny_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 68 }, Maximum = new Maximum { Unit = "F", Value = 67 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(14),
                    Day = new Day{ Phrase = "fluent_weather_sunny_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 65 }, Maximum = new Maximum { Unit = "F", Value = 67 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(15),
                    Day = new Day{ Phrase = "fluent_weather_sunny_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 63 }, Maximum = new Maximum { Unit = "F", Value = 67 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(16),
                    Day = new Day{ Phrase = "fluent_weather_sunny_20_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 60 }, Maximum = new Maximum { Unit = "F", Value = 67 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(17),
                    Day = new Day{ Phrase = "fluent_weather_moon_16_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 58 }, Maximum = new Maximum { Unit = "F", Value = 67 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(18),
                    Day = new Day{ Phrase = "fluent_weather_moon_16_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 54 }, Maximum = new Maximum { Unit = "F", Value = 67 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(19),
                    Day = new Day{ Phrase = "fluent_weather_moon_16_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 53 }, Maximum = new Maximum { Unit = "F", Value = 67 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(20),
                    Day = new Day{ Phrase = "fluent_weather_moon_16_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 52 }, Maximum = new Maximum { Unit = "F", Value = 67 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(21),
                    Day = new Day{ Phrase = "fluent_weather_moon_16_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 50 }, Maximum = new Maximum { Unit = "F", Value = 67 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(22),
                    Day = new Day{ Phrase = "fluent_weather_moon_16_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 47 }, Maximum = new Maximum { Unit = "F", Value = 67 } },
                },
                new Forecast
                {
                    DateTime = DateTime.Now.AddHours(23),
                    Day = new Day{ Phrase = "fluent_weather_moon_16_filled" },
                    Temperature = new Temperature{ Minimum = new Minimum{ Unit = "F", Value = 47 }, Maximum = new Maximum { Unit = "F", Value = 67 } },
                }
            };
    }

    public async Task LoadWeatherDataAsync()
    {
        await GetLocationAsync();

        GeoMetWeatherService weatherService = new GeoMetWeatherService();
        ReverseGeocodeService ReverseGeocodeService = new ReverseGeocodeService();
        string endpoint = "https://api.open-meteo.com/v1/forecast?latitude=" + Latitude + "&longitude=" + Longitude + "&current=temperature_2m,wind_speed_10m&hourly=temperature_2m,relative_humidity_2m,wind_speed_10m";
        WeatherData weatherData = await weatherService.GetWeatherDataAsync(endpoint);
        LocationData locationData = await ReverseGeocodeService.GetCityNameAsync(Latitude, Longitude);
        UpdateWeatherForecast(weatherData);
        WeatherDescription = $"{locationData.Address.City + ", " + locationData.Address.State}";
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
                Debug.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
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

    public void UpdateWeatherForecast(WeatherData weatherData)
    {
        if(Hours == null) { return; }
        for (int i = 0; i < Hours.Count; i++)
        {
            Hours[i].Temperature.Minimum.Value = (int)weatherData.Hourly.Temperature2m[i];
            Debug.Print("Temperature: " + weatherData.Hourly.Temperature2m[i]);
            Hours[i].Temperature.Maximum.Value = (int)weatherData.Hourly.Temperature2m[i];
        }
    }
}