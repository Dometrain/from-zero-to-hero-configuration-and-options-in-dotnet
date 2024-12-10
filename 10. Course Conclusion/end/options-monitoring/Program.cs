using Options.Monitoring.SensorStation;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<SensorFactory>();
builder.Services.AddHostedService<SensorMonitorService>();

builder.Services.AddOptionsWithValidateOnStart<SensorStationOptions>()
    .BindConfiguration(configSectionPath: 
        SensorStationOptions.SensorStationOptionsSectionName)
    .ValidateDataAnnotations();

var host = builder.Build();
host.Run();
