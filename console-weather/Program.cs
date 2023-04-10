// "Weather" class example:
using console_weather.Model;
using Newtonsoft.Json;

// Show API respond
ApiData data = new ApiData();
var weather = data.ParseData();
Console.WriteLine(weather.ToString());