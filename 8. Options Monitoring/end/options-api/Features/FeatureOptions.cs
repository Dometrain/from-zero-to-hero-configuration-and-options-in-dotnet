namespace Options.Api.Features;

/// <summary>
/// A representation of a "feature" options object.
/// </summary>
public sealed class FeatureOptions
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
}