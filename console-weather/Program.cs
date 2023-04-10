// "Weather" class example:
using console_weather.Model;
using Newtonsoft.Json;

// Show API respond
ApiData data = new ApiData();
var strings = data.GetRequest();
var json = JsonConvert.DeserializeObject<Weather>(strings);
Console.WriteLine(json.ToString());