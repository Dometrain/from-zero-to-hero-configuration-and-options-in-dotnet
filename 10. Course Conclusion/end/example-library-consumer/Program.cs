using Example.Library;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

var builder = Host.CreateApplicationBuilder(args);

#region .AddWidgetServices(IConfiguration config)

// The Add* API expects an IConfiguration
// that's named "WidgetOptions".
//builder.Services.AddWidgetServices(
//    widgetConfigSection: builder.Configuration.GetSection(
//        key: nameof(WidgetOptions)));

#endregion

#region .AddWidgetServices(string configSectionPath)

// The Add* API expects a string that represents the path
// to map to the "WidgetOptions" object.
//builder.Services.AddWidgetServices(
//    configSectionPath: "WidgetOptions");

#endregion

#region .AddWidgetServices(WidgetOptions widgetOptions)

// The Add* API expects a WidgetOptions instance.
//builder.Services.AddWidgetServices(
//    widgetOptions: new WidgetOptions
//    {
//        Color = "Red",
//        ImageUrl = "https://bit.ly/net-widget",
//        Size = 420,
//        IsEnabled = true,
//        Opacity = 0.69
//    });

#endregion

#region .AddWidgetServices(Action<WidgetOptions> configureOptions)

// The Add* API expects an options delegate (Action<WidgetOptions>)
// that's used to override option values.
builder.Services.AddWidgetServices(
    configureOptions: static options =>
    {
        options.Color = "Green";
        options.ImageUrl = "https://bit.ly/net-widget";
        options.IsEnabled = false;
        options.Size = 77;
        options.Opacity = 1;
    });

#endregion

var host = builder.Build();

await host.StartAsync();

// TODO:
// Consume available options interfaces:
//   - IOptions<WidgetOptions>
//   - IOptionsSnapshot<WidgetOptions>
//   - IOptionsMonitor<WidgetOptions>
// in a custom registered service.

var options = 
    host.Services.GetRequiredService<IOptions<WidgetOptions>>();

var widgetOptions = options.Value;

if (widgetOptions is not null)
{
}