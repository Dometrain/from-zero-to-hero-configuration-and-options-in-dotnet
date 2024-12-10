namespace GettingStarted;

public sealed class Worker(
    ILogger<Worker> logger,
    IConfiguration config) : BackgroundService
{
    protected override async Task ExecuteAsync(
        CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation(
                    "Worker running at: {time}", 
                    DateTimeOffset.Now);
            }

            var delay =
                config.GetValue<TimeSpan>(
                    "Delay",
                    TimeSpan.FromSeconds(5));

            await Task.Delay(
                delay, stoppingToken);
        }
    }
}
