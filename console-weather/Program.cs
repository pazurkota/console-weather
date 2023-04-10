// "Weather" class example:
using console_weather.Model;

// Show API respond
ApiData data = new ApiData();
var strings = data.GetRequest();
Console.WriteLine(strings);