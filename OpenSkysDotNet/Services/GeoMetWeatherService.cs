﻿using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace OpenSkysDotNet.Services
{
    public class GeoMetWeatherService
    {
        //singleton pattern
        private static GeoMetWeatherService _instance;
        private static readonly object _lock = new object();
        private WeatherData _cachedWeatherData;

        private static readonly HttpClient httpClient = new HttpClient();

        private double Latitude { get; set; }
        private double Longitude { get; set; }

        public static GeoMetWeatherService Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new GeoMetWeatherService();
                    }
                    return _instance;
                }
            }
        }

        public async Task<WeatherData> GetWeatherDataAsync()
        {
            if(Latitude == 0 || Longitude == 0)
            {
                await GetLocation();
            }
            string endPoint2 = "https://api.open-meteo.com/v1/forecast?latitude=" + Latitude + "&longitude=" + Longitude + "&current=temperature_2m,apparent_temperature,precipitation,rain,showers,weather_code,wind_speed_10m" +
                "&hourly=temperature_2m,precipitation,rain,showers,weather_code,wind_speed_10m,wind_gusts_10m" +
                "&daily=weather_code,temperature_2m_max,temperature_2m_min,precipitation_sum,rain_sum,showers_sum&timezone=America%2FNew_York";
            string endPoint = "https://api.open-meteo.com/v1/forecast?latitude=" + Latitude + "&longitude=" + Longitude +
                "&current=temperature_2m,wind_speed_10m,weather_code&" +
                "hourly=temperature_2m,relative_humidity_2m,wind_speed_10m,weather_code";
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(endPoint2);
                response.EnsureSuccessStatusCode();

                string responseData = await response.Content.ReadAsStringAsync();
                WeatherData weatherData = JsonSerializer.Deserialize<WeatherData>(responseData);

                return weatherData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching weather data", ex);
            }
        }

        private async Task GetLocation()
        {
            await ReverseGeocodeService.Instance.GetLocationAsync();

            Latitude = ReverseGeocodeService.Instance.GetLatitude();
            Longitude = ReverseGeocodeService.Instance.GetLongitude();
        }
    }
}
