using Microsoft.Extensions.Options;

namespace Options.Monitoring.SensorStation;

internal sealed class SensorMonitorService : BackgroundService
{
    private readonly SensorFactory _sensorFactory;
    private readonly IOptionsMonitor<SensorStationOptions> _options;
    private readonly ILogger<SensorMonitorService> _logger;
    private readonly IDisposable? _onChangeDisposable;

    public SensorMonitorService(
        SensorFactory sensorFactory,
        IOptionsMonitor<SensorStationOptions> options,
        ILogger<SensorMonitorService> logger)
    {
        _sensorFactory = sensorFactory;
        _options = options;
        _logger = logger;
        _onChangeDisposable = options.OnChange(OnOptionsChanged);
    }

    protected override async Task ExecuteAsync(
        CancellationToken stoppingToken)
    {
        _logger.LogInformation("""
            Current sensor station options:
              {Options}
            """,
            _options.CurrentValue);

        while (!stoppingToken.IsCancellationRequested)
        {
            var options = _options.CurrentValue;

            foreach (var (sensor, thresholds) in 
                options.Sensors ?? [])
            {
                var service = _sensorFactory.Create(sensor);

                var temp = service.ReadTemperature();

                AlertSensorReadings(sensor, temp, thresholds);
            }

            await Task.Delay(
                options.PollingInterval, stoppingToken);
        }
    }

    private void AlertSensorReadings(
        string sensor, double temp, ThresholdOptions thresholds)
    {
        var isLowerThanOrAtMax = temp <= thresholds.High;
        var isGreaterThanOrAtMin = temp >= thresholds.Low;

        if (isLowerThanOrAtMax && isGreaterThanOrAtMin)
        {
            _logger.LogInformation(
                "Normal '{Sensor}' reading: {Temp:F2}°F",
                sensor, temp);
        }
        else
        {
            // TODO: Send actual alert...

            _logger.LogCritical("""
                Wow! The '{Sensor}' reading is out of range: {Temp:F2}°F
                """,
                sensor, temp);
        }
    }

    private void OnOptionsChanged(SensorStationOptions latestOptions)
    {
        _logger.LogInformation("""
            Threshold's changed:
              {Options}
            """,
            latestOptions);
    }

    public override void Dispose()
    {
        _onChangeDisposable?.Dispose();

        base.Dispose();
    }
}
