﻿using System;
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
    public CurrentUnits CurrentUnits { get; set; }

    [JsonPropertyName("current")]
    public CurrentWeather Current { get; set; }

    [JsonPropertyName("hourly_units")]
    public HourlyUnits HourlyUnits { get; set; }

    [JsonPropertyName("hourly")]
    public HourlyWeather Hourly { get; set; }
}

public class CurrentUnits
{
    [JsonPropertyName("time")]
    public string Time { get; set; }

    [JsonPropertyName("interval")]
    public string Interval { get; set; }

    [JsonPropertyName("temperature_2m")]
    public string Temperature2m { get; set; }

    [JsonPropertyName("wind_speed_10m")]
    public string WindSpeed10m { get; set; }
}

public class CurrentWeather
{
    [JsonPropertyName("time")]
    public DateTime Time { get; set; }

    [JsonPropertyName("interval")]
    public int Interval { get; set; }

    [JsonPropertyName("temperature_2m")]
    public double Temperature2m { get; set; }

    [JsonPropertyName("wind_speed_10m")]
    public double WindSpeed10m { get; set; }
}

public class HourlyUnits
{
    [JsonPropertyName("time")]
    public string Time { get; set; }

    [JsonPropertyName("temperature_2m")]
    public string Temperature2m { get; set; }

    [JsonPropertyName("relative_humidity_2m")]
    public string RelativeHumidity2m { get; set; }

    [JsonPropertyName("wind_speed_10m")]
    public string WindSpeed10m { get; set; }
}

public class HourlyWeather
{
    [JsonPropertyName("time")]
    public List<DateTime> Time { get; set; }

    [JsonPropertyName("temperature_2m")]
    public List<double> Temperature2m { get; set; }

    [JsonPropertyName("relative_humidity_2m")]
    public List<double> RelativeHumidity2m { get; set; }

    [JsonPropertyName("wind_speed_10m")]
    public List<double> WindSpeed10m { get; set; }
}
