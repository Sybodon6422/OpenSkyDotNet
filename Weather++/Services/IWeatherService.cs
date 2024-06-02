namespace WeatherClient__;

public interface IWeatherService
{
    Task<IEnumerable<Location>> GetLocations(string query);
    Task<WeatherResponse> GetWeather(Coordinate location);
}