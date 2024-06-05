using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSkysDotNet.Resources
{
    internal static class PickImageFromData
    {
        public static string GetImagePath(int weatherCode)
        {
            return weatherCode switch
            {
                0 => "fluent_weather_sunny_high_20_filled",
                1 => "weather_partly_cloudy_day",
                2 => "weather_partly_cloudy_day",
                3 => "fluent_weather_sunny_high_20_filled",
                45 => "fluent_weather_fog_20_filled",
                48 => "fluent_weather_fog_20_filled",
                51 => "fluent_weather_drizzle_20_filled",
                53 => "fluent_weather_drizzle_20_filled",
                55 => "fluent_weather_drizzle_20_filled",
                56 => "fluent_weather_drizzle_20_filled",
                57 => "fluent_weather_drizzle_20_filled",
                61 => "fluent_weather_rain_20_filled",
                63 => "fluent_weather_rain_20_filled",
                65 => "fluent_weather_rain_20_filled",
                66 => "fluent_weather_rain_20_filled",
                67 => "fluent_weather_rain_20_filled",
                71 => "fluent_weather_snow_20_filled",
                73 => "fluent_weather_snow_20_filled",
                75 => "fluent_weather_snow_20_filled",
                77 => "fluent_weather_snow_20_filled",
                80 => "fluent_weather_rain_20_filled",
                81 => "fluent_weather_rain_20_filled",
                82 => "fluent_weather_rain_20_filled",
                85 => "fluent_weather_snow_20_filled",
                86 => "fluent_weather_snow_20_filled",
                95 => "fluent_weather_thunderstorm_20_filled",
                96 => "fluent_weather_thunderstorm_20_filled",
                99 => "fluent_weather_thunderstorm_20_filled",
                _ => "fluent_weather_sunny_20_filled",
            };
        }

        public static string GetWeatherDescription(int weatherCode)
        {
            return weatherCode switch
            {
                0 => "Clear sky",
                1 => "Mainly clear",
                2 => "Partly cloudy",
                3 => "Overcast",
                45 => "Fog",
                48 => "Depositing rime fog",
                51 => "Drizzle: Light intensity",
                53 => "Drizzle: Moderate intensity",
                55 => "Drizzle: Dense intensity",
                56 => "Freezing Drizzle: Light intensity",
                57 => "Freezing Drizzle: Dense intensity",
                61 => "Rain: Slight intensity",
                63 => "Rain: Moderate intensity",
                65 => "Rain: Heavy intensity",
                66 => "Freezing Rain: Light intensity",
                67 => "Freezing Rain: Heavy intensity",
                71 => "Snow fall: Slight intensity",
                73 => "Snow fall: Moderate intensity",
                75 => "Snow fall: Heavy intensity",
                77 => "Snow grains",
                80 => "Rain showers: Slight intensity",
                81 => "Rain showers: Moderate intensity",
                82 => "Rain showers: Violent intensity",
                85 => "Snow showers: Slight intensity",
                86 => "Snow showers: Heavy intensity",
                95 => "Thunderstorm: Slight intensity",
                96 => "Thunderstorm: Moderate intensity",
                99 => "Thunderstorm: Heavy intensity",
                _ => "Unknown weather code",
            };
            }

        /*0 	    Clear sky
        1, 2, 3 	Mainly clear, partly cloudy, and overcast
        45, 48 	    Fog and depositing rime fog
        51, 53, 55 	Drizzle: Light, moderate, and dense intensity
        56, 57 	    Freezing Drizzle: Light and dense intensity
        61, 63, 65 	Rain: Slight, moderate and heavy intensity
        66, 67 	    Freezing Rain: Light and heavy intensity
        71, 73, 75 	Snow fall: Slight, moderate, and heavy intensity
        77 	        Snow grains
        80, 81, 82 	Rain showers: Slight, moderate, and violent
        85, 86 	    Snow showers slight and heavy
        95 * 	    Thunderstorm: Slight or moderate
        96, 99 * 	Thunderstorm with slight and heavy hail*/
    }
}
