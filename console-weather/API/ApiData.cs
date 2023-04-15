// API Documentation:
// https://www.weatherapi.com/docs/

using System.Net;
using Newtonsoft.Json;
using RestSharp;

namespace console_weather.API; 

public class ApiData {
    private const string BASE_URL = "http://api.weatherapi.com/v1/"; // Base API URL
    public static string CITYNAME; // City name

    // Get request from API
    private string GetRequest() {
        string? apiKey = ApiKeyHandler.GetApiKey();
        string cityName = CITYNAME;

        try {
            // Client options
            var options = new RestClientOptions(BASE_URL) {
                ThrowOnAnyError = true
            };
            
            var client = new RestClient(options);
            var request = new RestRequest($"forecast.json?key={apiKey}&q={cityName}&aqi=no&alerts=yes");

            var response = client.Execute(request);

            // Throw error if responded with code 401 (unauthorized access)
            if (response.StatusCode == HttpStatusCode.Unauthorized) {
                throw new HttpRequestException("Error 401: API Key is invalid or not given");
            }
            
            return response.ToString();
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
        
        return new Weather.Weather {
            Current = jsonText.Current,
            Location = jsonText.Location,
            Alerts = jsonText.Alerts
        };
    }
}