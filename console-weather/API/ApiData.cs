// API Documentation:
// https://www.weatherapi.com/docs/

using Newtonsoft.Json;
using RestSharp;
using static console_weather.API.ApiKeyHandler;
using static console_weather.Utility.Settings;

namespace console_weather.API; 

public static class ApiData {
    private const string BaseUrl = "https://api.weatherapi.com/v1/"; 
    
    private static string GetRequest() {
        string? apiKey = GetApiKey();
        string cityName = CityName;

        try {
            while (!CheckApiKeyValidity(apiKey)) {
                SetApiKey();
                apiKey = GetApiKey();
            }
            
            var options = new RestClientOptions(BaseUrl) {
                ThrowOnAnyError = true
            };
            
            var client = new RestClient(options);
            var request = new RestRequest($"forecast.json?key={apiKey}&q={cityName}&aqi=yes&alerts=yes&days=2");

            var response = client.Execute(request).Content;

            if (response is null) {
                throw new Exception("The response is null");
            }
            
            return response;
        }
        catch (Exception e) {
            Console.WriteLine($"Error while executing program: {e}");
            throw;
        }
    }
    
    private static bool CheckApiKeyValidity(string? apiKey)
    {
        var client = new RestClient(BaseUrl);
        var request = new RestRequest($"forecast.json?key={apiKey}&q=Warsaw&aqi=no&alerts=no");
        
        var response = client.Execute(request);
        
        return response.IsSuccessful;
    }
    
    public static Weather.Weather ParseData() {
        var apiData = GetRequest();
        var jsonText = JsonConvert.DeserializeObject<Weather.Weather>(apiData);
        
        // Check if JSON file is null
        if (jsonText == null) {
            throw new NullReferenceException("The JSON file is empty or null");
        }
        
        return new Weather.Weather {
            Current = jsonText.Current,
            Location = jsonText.Location,
            Alerts = jsonText.Alerts,
            Forecast = jsonText.Forecast
        };
    }
}