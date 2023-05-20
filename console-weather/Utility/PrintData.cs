using console_weather.API;

namespace console_weather.Utility; 

public static class PrintData {
    private static readonly Units UnitType = new (Settings.Units);
    private static readonly Weather.Weather Data = ApiData.ParseData();
    
    public static string Print() {
        string str = "";
        
            str += $"Current weather for {Data.Location.Name} in {Data.Location.Country} is {Data.Current.Condition.ConditionState}\n";
            str += ShowTemperature(UnitType, Data);
            str += ShowAlerts();
            str += $"Current Wind Speed: {ShowWindSpeed(UnitType, Data)} ({Data.Current.WindDirection})\n";
            str += $"Current Air Pressure: {Data.Current.PressureMb} mbar\n";
            str += $"Current Visibility: {ShowVisibility(UnitType, Data)}\n";
            str += $"Current Humidity: {Data.Current.Humidity}%\n";
            str += $"Current Cloud Cover: {Data.Current.Cloud}%";
            str += ShowForecast();
            str += ShowAirQuality();
            str += $"\n\nLast Update: {Data.Current.LastUpdated}";

        return str;
    }

    private static string ShowAlerts() {
        var alerts = Data.Alerts;

        if (Settings.DontShowAlerts || alerts.WeatherAlerts.Count == 0) {
            return "";
        }

        return alerts.WeatherAlerts.Aggregate("", (current, alert) => current + $"{alert.AlertHeadline}:\n{alert.AlertDescription}\n\n");
    }

    private static string ShowForecast() {
        if (!Settings.ShowForecast) {
            return "";
        }

        string str = "";
        
        var forecast = Data
            .Forecast
            .ForecastsDay[1]
            .Day;

        str += $"\n\nTomorrow it will be {forecast.Condition.ConditionState}";
        str += $"{ShowForecastTemp()}";
        str += $"\nMaximum Wind Speed: {ShowForecastWindSpeed()}";
        str += $"\nAverage Visibility: {ShowForecastVisibility()}";
        str += $"\nChance of rain/snow: {forecast.ChanceOfRain}% / {forecast.ChanceOfSnow}%";
        
        return str;
    }
    
    #region Print weather data

    private static string ShowTemperature(Units unitType, Weather.Weather data) {
        if (unitType.Unit == Units.UnitType.Us) {
            return $"The temperature is {data.Current.TemperatureF}°F, but feels like {data.Current.FeelsLikeF}°F\n\n";
        }
        
        return $"The temperature is {data.Current.TemperatureC}°C, but feels like {data.Current.FeelsLikeC}°C\n\n";
    }

    private static string ShowWindSpeed(Units unitType, Weather.Weather data) {
        switch (unitType.Unit) {
            case Units.UnitType.Si:
                return $"{Math.Round(data.Current.WindSpeedKph * 1000/3600, 1)} m/s";
            case Units.UnitType.Eu:
                return $"{data.Current.WindSpeedKph} kph";
            default:
                return $"{data.Current.WindSpeedMph} mph";
        }
    }

    private static string ShowVisibility(Units unitType, Weather.Weather data) {
        var visibility = data
            .Forecast
            .ForecastsDay[0]
            .Day;

        if (unitType.Unit == Units.UnitType.Us) {
            return $"{visibility.AvgVisibilityMiles} miles";
        }

        return $"{visibility.AvgVisibilityKm} kilometers";
    }

    #endregion

    #region Print Air Quality data
    
    private static string ShowAirQuality() {
        if (!Settings.ShowAirQuality) {
            return "";
        }

        var airQuality = Data
            .Current
            .AirQuality;
        
        string str = "";
        
        str += "\n\nCurrent Air Quality:\n";
        str += $"Carbon Monoxide: {Math.Round(airQuality.Co, 2)} μg/m³\n";
        str += $"Nitrogen Dioxide: {Math.Round(airQuality.No2, 2)} μg/m³\n";
        str += $"Ozone: {Math.Round(airQuality.O3, 2)} μg/m³\n";
        str += $"Sulphur Dioxide: {Math.Round(airQuality.So2, 2)} μg/m³\n";
        str += $"Fine Particles Matter: {Math.Round(airQuality.Pm25, 2)} μg/m³\n";
        str += $"Coarse Particles Matter: {Math.Round(airQuality.Pm10, 2)} μg/m³\n";
        str += $"US Epa Index: {airQuality.UsEpaIndex} ({PrintEpaStandards(airQuality.UsEpaIndex)})";
        
        return str;
    }

    private static string PrintEpaStandards(int index) {
        switch (index) {
            case 1:
                return "Good";
            case 2:
                return "Moderate";
            case 3:
                return "Unhealthy for Sensitive Groups";
            case 4:
                return "Unhealthy";
            case 5:
                return "Very Unhealthy";
            case 6:
                return "Hazardous";
            default:
                return "Unknown";
        }
    }

    #endregion

    #region Print forecast data

    private static string ShowForecastTemp() {
        var forecast = Data
            .Forecast
            .ForecastsDay[1]
            .Day;
        
        if (UnitType.Unit == Units.UnitType.Us) {
            return $"\nTemperature Range: {forecast.MinTempF}°F - {forecast.MaxTempF}°F (average: {forecast.AvgTempF})°F";
        }
        
        return $"\nTemperature Range: {forecast.MinTempC}°C - {forecast.MaxTempC}°C (average: {forecast.AvgTempC})°C";
    }

    private static string ShowForecastWindSpeed() {
        var forecast = Data
            .Forecast
            .ForecastsDay[1]
            .Day;
        
        switch (UnitType.Unit) {
            case Units.UnitType.Si:
                return $"{Math.Round(forecast.MaxWindSpeedKph * 1000/3600, 1)} m/s";
            case Units.UnitType.Eu:
                return $"{forecast.MaxWindSpeedKph} kph";
            default:
                return $"{forecast.MaxWindSpeedMph} mph";
        }
    }
    
    private static string ShowForecastVisibility() {
        var forecast = Data
            .Forecast
            .ForecastsDay[1]
            .Day;
        
        if (UnitType.Unit == Units.UnitType.Us) {
            return $"{forecast.AvgVisibilityMiles} miles";
        }

        return $"{forecast.AvgVisibilityKm} kilometers";
    }

    #endregion
}