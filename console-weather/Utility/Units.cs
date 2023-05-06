namespace console_weather.Utility;

public class Units {
    public enum UnitType { Si, Us, Uk, Eu }
    public UnitType Unit;

    public Units(UnitType unitType) {
        Unit = unitType;
    }

    public string GetTempUnit() {
        switch (Unit) {
            case UnitType.Si:
                return "°C";
            case UnitType.Us:
                return "°F";
            case UnitType.Uk:
                return "°C";
            case UnitType.Eu:
                return "°C";
            default:
                throw new ArgumentException("Invalid unit type");
        }
    }
    
    public string GetWindSpeedUnit() {
        switch (Unit) {
            case UnitType.Si:
                return "m/s";
            case UnitType.Us:
                return "mph";
            case UnitType.Uk:
                return "mph";
            case UnitType.Eu:
                return "kph";
            default:
                throw new ArgumentException("Invalid unit type");
        }
    }
    
    public string GetPressureUnit() {
        return "hPa";
    }

    public void SetUnitType(string unitStr) {
        if (Enum.TryParse(unitStr, true, out UnitType unitType)) {
            Unit = unitType;
        }
        else {
            throw new ArgumentException("Invalid unit type");
        }
    }
}