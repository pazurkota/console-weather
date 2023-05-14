namespace console_weather.Utility;

public class Units {
    public enum UnitType { Si, Us, Uk, Eu }
    public UnitType Unit { get; set; }

    public Units(UnitType unitType) {
        Unit = unitType;
    }
}