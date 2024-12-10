namespace Yaml.Config;

public sealed class Worker(
    ILogger<Worker> logger,
    IConfiguration config) : BackgroundService
{
    protected override async Task ExecuteAsync(
        CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var delay =
                config.GetValue<TimeSpan>(
                    "Delay",
                    TimeSpan.FromSeconds(5));

            if (logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation(
                    "Worker running at ({delay}): {time}", 
                    delay, DateTimeOffset.Now);
            }

            await Task.Delay(
                delay, stoppingToken);
        }
    }
}
