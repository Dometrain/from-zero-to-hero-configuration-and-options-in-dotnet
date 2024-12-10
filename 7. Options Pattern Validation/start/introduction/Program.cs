using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder();

builder.AddInMemoryCollection([
        new("Key", "123 That was easy..."),
        new("Nested:Sub:Section", Math.PI.ToString()),
        new("ConnectionStrings:Example", "<example-database-cs>")
    ]);

#region builder.Sources ↻

foreach (var source in builder.Sources)
{
    Console.WriteLine($"""
        Source:
          {source}
        """);
}

Console.WriteLine();
#endregion

var config = builder.Build();

#region config.Providers ↻

foreach (var provider in config.Providers)
{
    Console.WriteLine($"""
        Provider:
          {provider}
        """);
}

Console.WriteLine();
#endregion

#region config.GetChildren();

RecurseConfigSections(config);

static void RecurseConfigSections(
    IConfiguration section,
    string? parentKey = null)
{
    foreach (var child in section.GetChildren())
    {
        var fullKey = parentKey is not null
            ? $"{parentKey}:{child.Key}"
            : child.Key;

        Console.WriteLine($"{fullKey}: {child.Value}");

        RecurseConfigSections(child, parentKey: fullKey);
    }
}

Console.WriteLine();
#endregion

#region config.GetSection("Nested:Sub:Section");

var section = config.GetSection("Nested:Sub:Section");

// Could just as easily use config["Nested:Sub:Section"];
Console.WriteLine($"""
    Value for "{section.Path}":
      {section.Value}
    """);

Console.WriteLine();
#endregion

#region config.GetConnectionString("Example");

var connectionString =
    config.GetConnectionString("Example");

Console.WriteLine($"""
    Example connection string value: {connectionString}
    """);
Console.WriteLine();
#endregion

#region config.GetDebugView();

Console.WriteLine(config.GetDebugView());

#endregion
