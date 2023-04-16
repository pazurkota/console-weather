// API Documentation:
// https://www.weatherapi.com/docs/

using System.Net;
using Newtonsoft.Json;
using RestSharp;
using static console_weather.API.ApiKeyHandler;

namespace console_weather.API; 

public class ApiData {
    private const string BASE_URL = "http://api.weatherapi.com/v1/"; // Base API URL
    public static string CITYNAME; // City name

    // Get request from API
    private string GetRequest() {
        string? apiKey = GetApiKey();
        string cityName = CITYNAME;

        try {
            // Get API Key if invalid or not given
            while (!CheckApiKeyValidity(apiKey)) {
                SetApiKey();
            }
            
            // Client options
            var options = new RestClientOptions(BASE_URL) {
                ThrowOnAnyError = true
            };
            
            var client = new RestClient(options);
            var request = new RestRequest($"forecast.json?key={apiKey}&q={cityName}&aqi=no&alerts=yes");

            var response = client.Execute(request).Content;

            return response;
        }
        catch (Exception e) {
            Console.WriteLine($"Error while executing program: {e}");
            throw;
        }
    }

    // Method to check if API key is valid or not
    public static bool CheckApiKeyValidity(string apiKey)
    {
        var client = new RestClient(BASE_URL);
        var request = new RestRequest($"forecast.json?key={apiKey}&q=Warsaw&aqi=no&alerts=yes");
        
        var response = client.Execute(request);

        // Check if the response status code indicates success
        if (response.IsSuccessful)
        {
            return true;
        }

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            return false;
        }
        
        Console.WriteLine($"Error: API returned status code {response.StatusCode}");
        return false;
    }
    
    // Parse data from API
    public Weather.Weather ParseData() {
        var apiData = GetRequest();
        var jsonText = JsonConvert.DeserializeObject<Weather.Weather>(apiData);
        
        // Check if JSON file is null
        if (jsonText == null) {
            throw new NullReferenceException("The JSON file is empty or null");
        }
        
        return new Weather.Weather {
            Current = jsonText.Current,
            Location = jsonText.Location,
            Alerts = jsonText.Alerts
        };
    }
}