using System.Text.Json.Serialization;

namespace OpenSkysDotNet.Models;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
public class Minimum
{
    public Minimum(double value, string unit)
    {
        Value = value;
        Unit = unit;
    }

    [JsonPropertyName("value")]
    public double Value { get; set; }

    [JsonPropertyName("unit")]
    public string Unit { get; set; }

}

public class Maximum
{
    public Maximum(double value, string unit)
    {
        Value = value;
        Unit = unit;
    }

    [JsonPropertyName("value")]
    public double Value { get; set; }

    [JsonPropertyName("unit")]
    public string Unit { get; set; }
}

public class Temperature
{
    [JsonPropertyName("minimum")]
    public Minimum Minimum { get; set; }

    [JsonPropertyName("maximum")]
    public Maximum Maximum { get; set; }

    public Temperature(Minimum newMinimum, Maximum  newMaximum)
    {
        Minimum = newMinimum;
        Maximum = newMaximum;
    }
}

public class Day
{
    [JsonPropertyName("phrase")]
    public string Phrase { get; set; }
}

public class Night
{
    [JsonPropertyName("phrase")]
    public string Phrase { get; set; }
}

public class Forecast
{
    [JsonPropertyName("dateTime")]
    public DateTime DateTime { get; set; }

    [JsonPropertyName("temperature")]
    public double TemperatureMin { get; set; }
    public double TemperatureMax { get; set; }

    public double PrecipitationSum { get; set; }

    [JsonPropertyName("day")]
    public Day Day { get; set; }

    [JsonPropertyName("night")]
    public Night Night { get; set; }
}

public class ForecastsPayload
{
    [JsonPropertyName("forecasts")]
    public List<Forecast> Forecasts { get; set; }
}