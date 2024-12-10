using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateEmptyApplicationBuilder(null);

// 📦 Microsoft.Extensions.Configuration.AzureAppConfiguration
// 📦 Azure.Identity

builder.Configuration.AddAzureAppConfiguration(
    static options =>
    {
        var connectionString =
            Environment.GetEnvironmentVariable("AZURE_APP_CONFIG_CONNECTION_STRING")
            ?? throw new InvalidOperationException("""
                A valid "AZURE_APP_CONFIG_CONNECTION_STRING" is required.
                """);
        // Connects to Azure App Configuration.
        options.Connect(connectionString);

        // Configures Azure Key Vault.
        options.ConfigureKeyVault(
            static kv => kv.SetCredential(
                credential: new AzureCliCredential()));
    });

Console.WriteLine(
    builder.Configuration.GetDebugView());