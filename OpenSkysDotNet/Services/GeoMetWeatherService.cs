using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Weather__.Services
{
    public class GeoMetWeatherService
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public async Task<WeatherData> GetWeatherDataAsync(string endpoint)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(endpoint);
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
    }
}
