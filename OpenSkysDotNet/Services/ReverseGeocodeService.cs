using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Weather__.Models;

namespace Weather__.Services
{
    public class ReverseGeocodeService
    {
        private static readonly HttpClient httpClient;
        static ReverseGeocodeService()
        {

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("OpenSkysDotNet/0.1 (BarkerSyobodon@outlook.com)");

        }

        public async Task<LocationData> GetCityNameAsync(double latitude, double longitude)
        {
            string url = $"https://nominatim.openstreetmap.org/reverse?format=json&lat={latitude}&lon={longitude}&addressdetails=1";

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
                return locationData;
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
