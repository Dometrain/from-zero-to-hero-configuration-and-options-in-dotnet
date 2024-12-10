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
                credential: new DefaultAzureCredential(
                    new DefaultAzureCredentialOptions
                {
                    // Only enable this credential locally
                    ExcludeAzureCliCredential = false,

                    // Exclude everything else...
                    ExcludeEnvironmentCredential = true,
                    ExcludeInteractiveBrowserCredential = true,
                    ExcludeAzurePowerShellCredential = true,
                    ExcludeSharedTokenCacheCredential = true,
                    ExcludeVisualStudioCodeCredential = true,
                    ExcludeVisualStudioCredential = true,
                    ExcludeManagedIdentityCredential = true,
                })));
    });

Console.WriteLine(
    builder.Configuration.GetDebugView());