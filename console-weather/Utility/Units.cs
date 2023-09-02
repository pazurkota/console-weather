namespace console_weather.Utility;

public class Units {
    public enum UnitType { Si, Us, Uk, Eu }
    public UnitType Unit { get; }

    public Units(UnitType unitType) {
        Unit = unitType;
    }
}