using Options.Validation;
using Options.Validation.Features;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddOptions<FeatureOptions>(name: "TodoApi")
    .BindConfiguration(configSectionPath: "Features:TodoApi")
    .ValidateDataAnnotations();

builder.Services.AddOptions<FeatureOptions>(name: "WeatherStation")
    .BindConfiguration(configSectionPath: "Features:WeatherStation")
    .ValidateDataAnnotations();

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
