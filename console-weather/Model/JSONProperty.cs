namespace console_weather.Model; 
using Newtonsoft.Json;

public struct JSONProperty {
    [JsonProperty("api-key")] // API Key, change in config.json
    public string APIKey { get; private set; } 
}