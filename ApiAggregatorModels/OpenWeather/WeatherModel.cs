namespace ApiAggregatorModels.OpenWeather;

public class WeatherModel
{
    public string Name { get; set; }
    public MainWeatherData Main { get; set; }
    public WeatherDescription[] Weather { get; set; }
}

public class MainWeatherData
{
    public double Temp { get; set; }
    public double Pressure { get; set; }
    public double Humidity { get; set; }
}

public class WeatherDescription
{
    public string Main { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
}

