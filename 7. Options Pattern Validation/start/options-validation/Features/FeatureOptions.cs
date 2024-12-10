using Microsoft.Extensions.Options;

namespace Options.Validation.Features;

/// <summary>
/// A representation of a "feature" options object.
/// </summary>
public sealed partial record class FeatureOptions : IValidateOptions<FeatureOptions>
{
    /// <summary>
    /// Gets or sets whether the feature is enabled.
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// Gets or sets the name of the feature.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the version of the feature.
    /// </summary>
    public Version? Version { get; set; }

    /// <summary>
    /// Gets or sets the endpoint (<see cref="Uri"/>) of the feature.
    /// </summary>
    public Uri? Endpoint { get; set; }

    /// <summary>
    /// Gets or sets the API key of the feature.
    /// </summary>
    public string? ApiKey { get; set; }

    /// <summary>
    /// Gets or sets any tags for the feature.
    /// </summary>
    public string[] Tags { get; set; } = [];

    /// <inheritdoc cref="IValidateOptions{TOptions}.Validate(string?, TOptions)" />
    public ValidateOptionsResult Validate(string? name, FeatureOptions options)
    {
        // Validate the "TodoApi" feature options
        if (IsNamed(name, expectedName: "TodoApi"))
        {
            if (options.Enabled is false)
            {
                return ValidateOptionsResult.Success;
            }

            List<string> failures = [];

            if (options is { Endpoint: null })
            {
                failures.Add("TODO API required a valid endpoint.");
            }

            if (options is { Version.Major: 0 })
            {
                failures.Add("TODO API running non-production version.");
            }

            if (failures.Count is > 0)
            {
                return ValidateOptionsResult.Fail(failures);
            }
        }

        if (IsNamed(name, expectedName: "WeatherStation") &&
            options is { Enabled: true })
        {
            return ValidateOptionsResult.Fail("""
                The weather station cannot be enabled in this environment.
                """);
        }

        return ValidateOptionsResult.Skip;

        static bool IsNamed(string? name, string expectedName)
        {
            return string.Equals(
                name, expectedName, 
                StringComparison.OrdinalIgnoreCase);
        }
    }
}