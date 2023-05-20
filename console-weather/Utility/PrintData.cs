using console_weather.API;

namespace console_weather.Utility; 

public static class PrintData {
    private static readonly Units UnitType = new (Settings.Units);
    private static readonly Weather.Weather Data = ApiData.ParseData();
    
    public static string Print() {
        string str = "";
            
            str += "CURRENT WEATHER:\n";
            str += $"Current weather for {Data.Location.Name} in {Data.Location.Country} is {Data.Current.Condition.ConditionState}\n";
            str += ShowTemperature();
            str += $"Current Wind Speed: {ShowWindSpeed()} ({Data.Current.WindDirection})\n";
            str += $"Current Air Pressure: {Data.Current.PressureMb} mbar\n";
            str += $"Current Visibility: {ShowVisibility()}\n";
            str += $"Current Precipitation: {ShowPrecipitation()}\n";
            str += $"Current Humidity: {Data.Current.Humidity}%\n";
            str += $"Current Cloud Cover: {Data.Current.Cloud}%";
            str += ShowAlerts();
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

        return alerts.WeatherAlerts.Aggregate("\n\nALERTS:\n", (current, alert) => current + $"{alert.AlertHeadline}:\n{alert.AlertDescription}\n\n");
    }

    private static string ShowForecast() {
        if (!Settings.ShowForecast) {
            return "";
        }

        string str = "";
        
        var forecast = Data.Forecast.ForecastsDay[1].Day;

        str += "\n\nFORECAST:";
        str += $"\nTomorrow it will be {forecast.Condition.ConditionState}";
        str += $"{ShowForecastTemp()}";
        str += $"\nMaximum Wind Speed: {ShowForecastWindSpeed()}";
        str += $"\nAverage Visibility: {ShowForecastVisibility()}";
        str += $"\nMaximum Precipitation: {ShowForecastPrecipitation()}";
        str += $"\nChance of rain/snow: {forecast.ChanceOfRain}% / {forecast.ChanceOfSnow}%";
        
        return str;
    }
    
    #region Print weather data

    private static string ShowTemperature() {
        if (UnitType.Unit == Units.UnitType.Us) {
            return $"The temperature is {Data.Current.TemperatureF}°F, but feels like {Data.Current.FeelsLikeF}°F\n\n";
        }
        
        return $"The temperature is {Data.Current.TemperatureC}°C, but feels like {Data.Current.FeelsLikeC}°C\n\n";
    }

    private static string ShowWindSpeed() {
        switch (UnitType.Unit) {
            case Units.UnitType.Si:
                return $"{Math.Round(Data.Current.WindSpeedKph * 1000/3600, 1)} m/s";
            case Units.UnitType.Eu:
                return $"{Data.Current.WindSpeedKph} kph";
            default:
                return $"{Data.Current.WindSpeedMph} mph";
        }
    }

    private static string ShowVisibility() {
        var visibility = Data.Current;

        if (UnitType.Unit == Units.UnitType.Us) {
            return $"{visibility.VisibilityMiles} miles";
        }

        return $"{visibility.VisibilityKm} kilometers";
    }
    
    private static string ShowPrecipitation() {
        var precipitation = Data.Current;

        if (UnitType.Unit == Units.UnitType.Us) {
            return $"{precipitation.PrecipitationIn} in";
        }

        return $"{precipitation.PrecipitationMm} mm";
    }

    #endregion

    #region Print Air Quality data
    
    private static string ShowAirQuality() {
        if (!Settings.ShowAirQuality) {
            return "";
        }

        var airQuality = Data.Current.AirQuality;
        
        string str = "";
        
        str += "\n\nAIR QUALITY:\n";
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
        var forecast = Data.Forecast.ForecastsDay[1].Day;
        
        if (UnitType.Unit == Units.UnitType.Us) {
            return $"\nTemperature Range: {forecast.MinTempF}°F - {forecast.MaxTempF}°F (average: {forecast.AvgTempF})°F";
        }
        
        return $"\nTemperature Range: {forecast.MinTempC}°C - {forecast.MaxTempC}°C (average: {forecast.AvgTempC})°C";
    }

    private static string ShowForecastWindSpeed() {
        var forecast = Data.Forecast.ForecastsDay[1].Day;
        
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
        var forecast = Data.Forecast.ForecastsDay[1].Day;
        
        if (UnitType.Unit == Units.UnitType.Us) {
            return $"{forecast.AvgVisibilityMiles} miles";
        }

        return $"{forecast.AvgVisibilityKm} kilometers";
    }
    
    private static string ShowForecastPrecipitation() {
        var forecast = Data.Forecast.ForecastsDay[1].Day;

        if (UnitType.Unit == Units.UnitType.Us) {
            return $"{forecast.PrecipitationIn} in";
        }

        return $"{forecast.PrecipitationMm} mm";
    }

    #endregion
}