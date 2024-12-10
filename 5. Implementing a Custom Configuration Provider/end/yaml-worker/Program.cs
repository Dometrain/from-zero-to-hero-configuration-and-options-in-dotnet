using DomeTrain.FromZeroToHero.Configuration.Yaml;
using Yaml.Config;

var builder = Host.CreateApplicationBuilder(args);

// Clear out all the default config sources.
builder.Configuration.Sources.Clear();

builder.Configuration.AddYamlFile(
    path: "app.yaml", 
    optional: false, 
    reloadOnChange: true);

builder.Configuration.AddYamlFile(
    path: $"app.{builder.Environment.EnvironmentName}.yaml",
    optional: false,
    reloadOnChange: true);

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
