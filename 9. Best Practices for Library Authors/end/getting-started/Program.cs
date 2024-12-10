using GettingStarted;

var builder =  
    Host.CreateApplicationBuilder(args);

_ = builder.Configuration;

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
