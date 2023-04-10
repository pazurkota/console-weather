namespace console_weather.Model; 

public class Weather {
    public string Date { get; set; }
    public string City { get; set; }
    public decimal Temperature { get; set; } 
    public string WeatherCondition { get; set; }
    public decimal WindSpeed { get; set; }
    public decimal Pressure { get; set; }
    public string AlertHeadline { get; set; }

    public override string ToString() {
        string str = $"Weather for {City} at {Date}";

        str += $"\nAverage Temperature: {Temperature}";
        str += $"\nWeather Condition: {WeatherCondition}";
        str += $"\nWind Speed: {WindSpeed}";
        str += $"\nAir Pressure: {Pressure}";
        str += $"\nAlert Headline: {AlertHeadline}";
        
        return str;
    }
}