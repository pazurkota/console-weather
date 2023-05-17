using console_weather.API;

namespace console_weather.Utility; 

public static class PrintData {
    private static readonly Units UnitType = new (Settings.Units);
    private static readonly Weather.Weather Data = ApiData.ParseData();
    
    public static string Print() {
        string str = "";

        if (Settings.ShowAirQuality) {
            str += $"Current Air Quality for {Data.Location.Name} in {Data.Location.Country}:\n\n";
            str += ShowAirQuality(Data);
        }
        else {
            str += $"Current weather for {Data.Location.Name} in {Data.Location.Country} is {Data.Current.Condition.ConditionState}\n";
            str += ShowTemperature(UnitType, Data);
            str += ShowAlerts();
            str += $"Current Wind Speed is {ShowWindSpeed(UnitType, Data)} {Data.Current.WindDirection}\n";
            str += $"Current Air Pressure is {Data.Current.PressureMb} mbar\n";
            str += $"Current Visibility is {ShowVisibility(UnitType, Data)}\n";
            str += $"Current Humidity is {Data.Current.Humidity}%\n";
            str += $"Current Cloud Cover is {Data.Current.Cloud}%\n";
            str += $"Last Update: {Data.Current.LastUpdated}";
            str += ShowForecast();   
        }

        return str;
    }

    private static string ShowAlerts() {
        var alerts = ApiData.ParseData().Alerts;

        if (Settings.DontShowAlerts || alerts.WeatherAlerts.Count == 0) {
            return "";
        }

        string str = "";

        foreach (var alert in alerts.WeatherAlerts) {
            str += $"{alert.AlertHeadline}:\n{alert.AlertDescription}\n\n";
        }
        
        return str;
    }

    private static string ShowForecast() {
        if (!Settings.ShowForecast) {
            return "";
        }

        string str = "";
        
        var forecast = ApiData.ParseData()
            .Forecast
            .ForecastsDay[0]
            .Day;

        str += $"\n\nTomorrow it will be {forecast.Condition.ConditionState}";
        str += $"{ShowForecastTemp(UnitType, Data)}";
        str += $"\nThe maximum wind speed will be around {ShowForecastWindSpeed(UnitType, Data)}";
        str += $"\nThe average visibility will be around {ShowForecastVisibility(UnitType, Data)}";
        str += $"\nThe chance of rain/snow: {forecast.ChanceOfRain}% / {forecast.ChanceOfSnow}%";
        
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
    
    private static string ShowAirQuality(Weather.Weather data) {
        if (!Settings.ShowAirQuality) {
            return "";
        }

        var airQuality = data
            .Current
            .AirQuality;
        
        string str = "";
        
        str += $"Carbon Monoxide: {Math.Round(airQuality.Co, 2)} μg/m³\n";
        str += $"Nitrogen Dioxide: {Math.Round(airQuality.No2, 2)} μg/m³\n";
        str += $"Ozone: {Math.Round(airQuality.O3, 2)} μg/m³\n";
        str += $"Sulphur Dioxide: {Math.Round(airQuality.So2, 2)} μg/m³\n";
        str += $"Fine Particles Matter: {Math.Round(airQuality.Pm25, 2)} μg/m³\n";
        str += $"Coarse Particles Matter: {Math.Round(airQuality.Pm10, 2)} μg/m³\n";
        str += $"US Epa Index: {airQuality.UsEpaIndex} ({PrintEpaStandards()})";
        
        return str;
    }

    private static string PrintEpaStandards() {
        var index = Data
            .Current
            .AirQuality
            .UsEpaIndex;

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

    private static string ShowForecastTemp(Units unitType, Weather.Weather data) {
        var forecast = data
            .Forecast
            .ForecastsDay[1]
            .Day;
        
        if (unitType.Unit == Units.UnitType.Us) {
            return $"\nThe temperature range will be around {forecast.MinTempF}°F to {forecast.MaxTempF}°F, with average of {forecast.AvgTempF}°F";
        }
        
        return $"\nThe temperature range will be around {forecast.MinTempC}°C to {forecast.MaxTempC}°C, with average of {forecast.AvgTempC}°C";
    }

    private static string ShowForecastWindSpeed(Units unitType, Weather.Weather data) {
        var forecast = data
            .Forecast
            .ForecastsDay[1]
            .Day;
        
        switch (unitType.Unit) {
            case Units.UnitType.Si:
                return $"{Math.Round(forecast.MaxWindSpeedKph * 1000/3600, 1)} m/s";
            case Units.UnitType.Eu:
                return $"{forecast.MaxWindSpeedKph} kph";
            default:
                return $"{forecast.MaxWindSpeedMph} mph";
        }
    }
    
    private static string ShowForecastVisibility(Units unitType, Weather.Weather data) {
        var forecast = data
            .Forecast
            .ForecastsDay[1]
            .Day;
        
        if (unitType.Unit == Units.UnitType.Us) {
            return $"{forecast.AvgVisibilityMiles} miles";
        }

        return $"{forecast.AvgVisibilityKm} kilometers";
    }

    #endregion
}