using console_weather.Controller;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace console_weather.Model; 

public class ApiData {
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
        string cityName = Entry.GetCityName();

        try {
            var client = new RestClient("http://api.weatherapi.com/v1/");
            var requset = new RestRequest($"current.json?key={apiKey}&q={cityName}&aqi=no");
            
            var response = client.Execute(requset).Content;
            Console.WriteLine(response);
        }
        catch (Exception e) {
            Console.WriteLine($"Error while executing program: {e}");
            throw;
        }
    }
}