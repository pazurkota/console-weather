using console_weather.Controller;
using Newtonsoft.Json;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace console_weather.Model; 

public class ApiData {
    private const string BASE_URL = "http://api.weatherapi.com/v1/"; // Base API URL
    
    // Get API Key from config.json
    private string GetApiKey() {
        var jsonText = File.ReadAllText("config.json");
        JObject config = JObject.Parse(jsonText);

        string key = config["api-key"].ToString();
        return key;
    }
    
    // Get request from API
    private string GetRequest() {
        string apiKey = GetApiKey();
        string cityName = Entry.GetCityName();

        try {
            var client = new RestClient(BASE_URL);
            var requset = new RestRequest($"current.json?key={apiKey}&q={cityName}&aqi=no");
            
            var response = client.Execute(requset).Content;
            return response;
        }
        catch (Exception e) {
            Console.WriteLine($"Error while executing program: {e}");
            throw;
        }
    }
    
    // Parse data from API
    public Weather.Weather ParseData() {
        var apiData = GetRequest();
        var jsonText = JsonConvert.DeserializeObject<Weather.Weather>(apiData);
        
        // Check if JSON file is null
        if (jsonText == null) {
            throw new NullReferenceException("The JSON file is empty or null");
        }
        
        return new Weather.Weather() {
            Current = jsonText.Current,
            Location = jsonText.Location
        };
    }
}