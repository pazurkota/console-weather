// "Weather" class example:
using console_weather.Model;

var weather = new Weather();

weather.City = "Example city";
weather.Temperature = 15;
weather.WeatherCondition = "Overcast";
weather.AlertHeadline = "Severe Thunderstorm Watch";

Console.WriteLine(weather.ToString());