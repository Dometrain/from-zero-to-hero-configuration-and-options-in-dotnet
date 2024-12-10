namespace Options.Monitoring.SensorStation;

internal sealed class FakeSensorService(
    double initialTemperature = 65, 
    double minChange = -0.05, 
    double maxChange = 0.5) : ISensorService
{
    private double _currentTemperature = initialTemperature;

    public double ReadTemperature()
    {
        // Help to emulate a somewhat realistic/gradual change
        var change = Random.Shared.NextDouble() * 
            (maxChange - minChange) + minChange;
        
        _currentTemperature += change;

        return _currentTemperature;
    }
}
