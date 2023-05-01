using Newtonsoft.Json;

namespace console_weather.Weather; 

public class Condition {
    [JsonProperty("text")] public string ConditionState { get; set; } = null!;
    [JsonProperty("code")] public int ConditionCode { get; set; }
}