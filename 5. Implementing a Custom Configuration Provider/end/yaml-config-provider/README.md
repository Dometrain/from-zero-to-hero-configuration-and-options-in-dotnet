# Implement a Custom Configuration Provider

1. Add reference to `Microsoft.Extensions.Configuration.Abstractions`.

2. Implement the `IConfigurationSource` interface.

3. Implement the `IConfigurationProvider` interface.

4. Write extension methods on the `IConfigurationBuilder` for adding sources.