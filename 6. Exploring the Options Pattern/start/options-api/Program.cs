var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions<LoggingOptions>()
    .Bind(config: builder.Configuration.GetSection(
        key: LoggingOptions.LoggingConfigurationSectionName));

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

app.Run();
