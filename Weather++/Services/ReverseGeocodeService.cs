using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Weather__.Services
{
    public class ReverseGeocodeService
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public async Task<string> GetCityNameAsync(double latitude, double longitude)
        {
            string url = $"https://nominatim.openstreetmap.org/reverse?format=json&lat={latitude}&lon={longitude}&addressdetails=1";

            var response = await httpClient.GetFromJsonAsync<OpenStreetMapResponse>(url);
            return response?.Address?.City;
        }
    }

    public class OpenStreetMapResponse
    {
        public Address Address { get; set; }
    }

    public class Address
    {
        public string City { get; set; }
    }
}
