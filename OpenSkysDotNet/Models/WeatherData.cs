using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class WeatherData
{
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("generationtime_ms")]
    public double GenerationTimeMs { get; set; }

    [JsonPropertyName("utc_offset_seconds")]
    public int UtcOffsetSeconds { get; set; }

    [JsonPropertyName("timezone")]
    public string Timezone { get; set; }

    [JsonPropertyName("timezone_abbreviation")]
    public string TimezoneAbbreviation { get; set; }

    [JsonPropertyName("elevation")]
    public double Elevation { get; set; }

    [JsonPropertyName("current_units")]
    public UnitTypeDefinition CurrentUnits { get; set; }

    [JsonPropertyName("current")]
    public CurrentForecast Current { get; set; }

    [JsonPropertyName("weather_code")]
    public int WeatherCode { get; set; }

    [JsonPropertyName("hourly_units")]
    public UnitTypeDefinition HourlyUnits { get; set; }

    [JsonPropertyName("hourly")]
    public ArrayedForecast Hourly { get; set; }

    [JsonPropertyName("daily_units")]
    public UnitTypeDefinition DailyUnits { get; set; }

    [JsonPropertyName("daily")]
    public ArrayedForecast Daily { get; set; }
}

public class UnitTypeDefinition
{
    [JsonPropertyName("time")]
    public string Time { get; set; }

    [JsonPropertyName("temperature_2m")]
    public string Temperature2m { get; set; }

    [JsonPropertyName("apparent_temperature")]
    public string ApparentTemperature { get; set; }

    [JsonPropertyName("precipitation")]
    public string Precipitation { get; set; }

    [JsonPropertyName("rain")]
    public string Rain { get; set; }

    [JsonPropertyName("showers")]
    public string Showers { get; set; }

    [JsonPropertyName("weather_code")]
    public string WeatherCode { get; set; }

    [JsonPropertyName("wind_speed_10m")]
    public string WindSpeed10m { get; set; }

    [JsonPropertyName("wind_gusts_10m")]
    public string WindGusts10m { get; set; }
}

public class CurrentForecast
{
    [JsonPropertyName("time")]
    public string Time { get; set; }

    [JsonPropertyName("interval")]
    public int Interval { get; set; }

    [JsonPropertyName("temperature_2m")]
    public double Temperature2m { get; set; }

    [JsonPropertyName("apparent_temperature")]
    public double ApparentTemperature { get; set; }

    [JsonPropertyName("precipitation")]
    public double Precipitation { get; set; }

    [JsonPropertyName("rain")]
    public double Rain { get; set; }

    [JsonPropertyName("showers")]
    public double Showers { get; set; }

    [JsonPropertyName("weather_code")]
    public int WeatherCode { get; set; }

    [JsonPropertyName("wind_speed_10m")]
    public double WindSpeed10m { get; set; }

    [JsonPropertyName("temperature_2m_max")]
    public double Temperature2mMax { get; set; }

    [JsonPropertyName("temperature_2m_min")]
    public double Temperature2mMin { get; set; }

    [JsonPropertyName("precipitation_sum")]
    public double PrecipitationSum { get; set; }

    [JsonPropertyName("rain_sum")]
    public double RainSum { get; set; }

    [JsonPropertyName("showers_sum")]
    public double ShowersSum { get; set; }
}

public class ArrayedForecast
{
    [JsonPropertyName("time")]
    public string[] Time { get; set; }

    [JsonPropertyName("interval")]
    public int[] Interval { get; set; }

    [JsonPropertyName("temperature_2m")]
    public double[] Temperature2m { get; set; }

    [JsonPropertyName("apparent_temperature")]
    public double[] ApparentTemperature { get; set; }

    [JsonPropertyName("precipitation")]
    public double[] Precipitation { get; set; }

    [JsonPropertyName("rain")]
    public double[] Rain { get; set; }

    [JsonPropertyName("showers")]
    public double[] Showers { get; set; }

    [JsonPropertyName("weather_code")]
    public int[] WeatherCode { get; set; }

    [JsonPropertyName("wind_speed_10m")]
    public double[] WindSpeed10m { get; set; }

    [JsonPropertyName("temperature_2m_max")]
    public double[] Temperature2mMax { get; set; }

    [JsonPropertyName("temperature_2m_min")]
    public double[] Temperature2mMin { get; set; }

    [JsonPropertyName("precipitation_sum")]
    public double[] PrecipitationSum { get; set; }

    [JsonPropertyName("rain_sum")]
    public double[] RainSum { get; set; }

    [JsonPropertyName("showers_sum")]
    public double[] ShowersSum { get; set; }
}
