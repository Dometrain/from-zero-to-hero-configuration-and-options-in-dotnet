using Microsoft.Extensions.Options;
using Options.Validation.Features;

namespace Options.Validation;

public sealed class Worker(
    ILogger<Worker> logger,
    IOptionsMonitor<FeatureOptions> options) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation(
                    "TODO API feature options: {Options}",
                    options.Get("TodoApi"));

                logger.LogInformation(
                    "Weather Station feature options: {Options}",
                    options.Get("WeatherStation"));
            }

            await Task.Delay(
                10_000, stoppingToken);
        }
    }
}
