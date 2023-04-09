using RestSharp;
using Newtonsoft.Json.Linq;

namespace console_weather.Model; 

public class APIData {
    // Get API Key from config.json
    private string GetApiKey() {
        var jsonText = File.ReadAllText("config.json");
        JObject config = JObject.Parse(jsonText);

        string key = config["api-key"].ToString();
        return key;
    }
    
    // Get request from API
    public void GetRequest() {
        string apiKey = GetApiKey();
        
        var client = new RestClient("http://api.weatherapi.com/v1/");
        var requset = new RestRequest($"current.json?key={apiKey}&q=Wroclaw&aqi=no");

        var response = client.Execute(requset).Content;
        Console.WriteLine(response);
    }
}