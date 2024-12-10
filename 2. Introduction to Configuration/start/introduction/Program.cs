using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder();

builder.AddInMemoryCollection([
        new("Key", "123 That was easy...")
    ]);

var config = builder.Build();

var value = config["Key"];

Console.WriteLine(value);