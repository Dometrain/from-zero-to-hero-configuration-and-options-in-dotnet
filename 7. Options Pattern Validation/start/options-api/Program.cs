var builder = WebApplication.CreateBuilder(args);

// Bind IOptions<LoggingOptions> to the
// "Logging" config section for DI.
builder.Services.AddOptions<LoggingOptions>()
    .Bind(config: builder.Configuration.GetSection(
        key: LoggingOptions.LoggingConfigurationSectionName));

// Add named configuration options.
builder.Services.AddOptions<FeatureOptions>(
        name: "TodoApi"
    )
    .Bind(config: builder.Configuration.GetSection(
        key: "Features:TodoApi"));

// Overrides (and/or merges) with existing configured bindings.
builder.Services.PostConfigure<FeatureOptions>(
    name: "WeatherStation",
    configureOptions: static (FeatureOptions options) =>
    {
        options.Version = new(1, 0);
        options.Endpoint = new(
            "https://freetestapi.com/api/v1/weathers");
        options.Tags =
        [
            "fake-weather",
            "test-api"
        ];
    });

// Override all config-bound instances of FeatureOptions.
builder.Services.PostConfigureAll<FeatureOptions>(
    configureOptions: 
        static (FeatureOptions options) => 
            options.Tags ??= []);

builder.Services.Configure<FeatureOptions>(
    name: "WeatherStation",
    config: builder.Configuration.GetSection(
        key: "Features:WeatherStation"));

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet( //   GET /logging/options HTTP/1.1
            //   Content-Type: application/json 
        pattern: "/logging/options",
        handler: static (IOptions<LoggingOptions> options) =>
    {
        var loggingOptions = options.Value;

        return Results.Json(
            data: loggingOptions);
    })
    .WithName("GetLoggingOptions")
    .WithOpenApi();

app.MapGet( //   GET /features HTTP/1.1
            //   Content-Type: application/json 
        pattern: "/features",
        handler: static (IOptionsSnapshot<FeatureOptions> options) =>
        {
            var todo = options.Get("TodoApi");
            var weatherStation = options.Get("WeatherStation");

            return Results.Json(
                data: new {
                    TodoApis = todo,
                    WeatherStation = weatherStation
                });
        })
    .WithName("GetFeatureOptions")
    .WithOpenApi();

app.Run();
