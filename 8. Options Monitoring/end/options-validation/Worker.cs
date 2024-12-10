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
                    GetNamedOptionsAsLogString("TodoApi"));

                logger.LogInformation(
                    "Weather Station feature options: {Options}",
                    GetNamedOptionsAsLogString("WeatherStation"));
            }

            await Task.Delay(
                10_000, stoppingToken);
        }
    }

    private string GetNamedOptionsAsLogString(string name)
    {
        try
        {
            return options.Get(name)?.ToString() ?? "";
        }
        catch (OptionsValidationException ex)
        {
            logger.LogError(
                "{Name} ({Type}): {Errors}",
                ex.OptionsName, ex.OptionsType, ex.Message);

            return "";
        }
    }
}
