using console_weather.API;

namespace console_weather.Icons; 

public static class IconsHandler {
    private static readonly string DayIconsPath = @"Icons\Day\";
    private static readonly string NightIconsPath = @"Icons\Night\";
    
    private static readonly int IsDay = ApiData.ParseData().Current.IsDay;
    private static readonly int ConditionCole = ApiData.ParseData().Current.Condition.ConditionCode;
    
    public static string GetIcon() {
        var icon = IsDay == 1 ? GetDayIcon() : GetNightIcon();
        var iconContent = File.ReadAllText(icon);
        
        return iconContent;
    }
    
    private static string GetDayIcon() {
        var dayIcons = Directory.GetFiles(DayIconsPath);
        var conditionCode = GetConditionCode()[ConditionCole];
        var icon = dayIcons.FirstOrDefault(icon => icon.Contains(conditionCode));

        return icon;
    }
    
    private static string GetNightIcon() {
        var nightIcons = Directory.GetFiles(NightIconsPath);
        var conditionCode = GetConditionCode()[ConditionCole];
        var icon = nightIcons.FirstOrDefault(icon => icon.Contains(conditionCode));

        return icon;
    }

    // Dictionary of condition codes and their corresponding icon names
    // More info: https://www.weatherapi.com/docs/weather_conditions.json
    private static Dictionary<int, string> GetConditionCode() {
        Dictionary<int, string> dictionary = new Dictionary<int, string>() {
            {1000, "113"},
            {1003, "116"},
            {1006, "119"},
            {1009, "122"},
            {1030, "143"},
            {1063, "176"},
            {1066, "179"},
            {1069, "182"},
            {1072, "185"},
            {1087, "200"},
            {1114, "227"},
            {1117, "230"},
            {1135, "248"},
            {1147, "260"},
            {1150, "263"},
            {1153, "266"},
            {1168, "281"},
            {1171, "284"},
            {1180, "293"},
            {1183, "296"},
            {1186, "299"},
            {1189, "302"},
            {1192, "305"},
            {1195, "308"},
            {1198, "311"},
            {1201, "314"},
            {1204, "317"},
            {1207, "320"},
            {1210, "323"},
            {1213, "326"},
            {1216, "329"},
            {1219, "332"},
            {1222, "335"},
            {1225, "338"},
            {1237, "350"},
            {1240, "353"},
            {1243, "356"},
            {1246, "359"},
            {1249, "362"},
            {1252, "365"},
            {1255, "368"},
            {1258, "371"},
            {1261, "374"},
            {1264, "377"},
            {1273, "386"},
            {1276, "389"},
            {1279, "392"},
            {1282, "395"},
        };

        return dictionary;
    }
}