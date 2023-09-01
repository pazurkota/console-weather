using console_weather.Weather;

namespace console_weather.Utility; 

public static class HourlyWeather {
    public static List<Hour> GetHourlyWeather(Weather.Weather data) {
        var localtime = DateTime.Parse(data.Location.LocalTime);
        var hourly = new List<Hour>();
        
        hourly.AddRange(data.Forecast.ForecastsDay[0].Hours);
        hourly.AddRange(data.Forecast.ForecastsDay[1].Hours);
        
        var sortedHourly = 
            hourly.Where(hour => hour.DateTime >= localtime && hour.DateTime <= localtime.AddHours(5)).OrderBy(hour => hour.Time).ToList();

        return sortedHourly;
    }
}