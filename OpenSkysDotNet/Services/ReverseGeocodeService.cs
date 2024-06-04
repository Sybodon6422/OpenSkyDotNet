using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Devices.Sensors;
using OpenSkysDotNet.Models;

namespace OpenSkysDotNet.Services
{
    public class ReverseGeocodeService
    {
        private static ReverseGeocodeService _instance;
        private static readonly object _lock = new object();
        private LocationData _cachedLocationData;


        private readonly HttpClient httpClient;

        private double Latitude { get; set; }
        private double Longitude { get; set; }

        public double GetLatitude()
        {
            return Latitude;
        }

        public double GetLongitude()
        {
            return Longitude;
        }

        public static ReverseGeocodeService Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ReverseGeocodeService();
                    }
                    return _instance;
                }
            }
        }

        private ReverseGeocodeService()
        {

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("OpenSkysDotNet/0.1 (BarkerSyobodon@outlook.com)");
        }

        public async Task GetLocationAsync()
        {
            if(Latitude != 0 && Longitude != 0)
            {
                return;
            }

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

        public async Task<LocationData> GetLocationDataasync()
        {
            if(Latitude == 0 || Longitude == 0)
            {
                await GetLocationAsync();
            }
            if(_cachedLocationData != null)
            {
                return _cachedLocationData;
            }

            string url = $"https://nominatim.openstreetmap.org/reverse?format=json&lat={Latitude}&lon={Longitude}&addressdetails=1";

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseData = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                LocationData locationData = JsonSerializer.Deserialize<LocationData>(responseData, options);
                _cachedLocationData = locationData;
                return _cachedLocationData;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error fetching location data", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected error", ex);
            }
        }
    }
}
