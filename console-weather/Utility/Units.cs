namespace console_weather.Utility;

public class Units {
    public enum UnitType { Si, Us, Uk, Eu }
    public UnitType Unit;

    public Units(UnitType unitType) {
        Unit = unitType;
    }
}