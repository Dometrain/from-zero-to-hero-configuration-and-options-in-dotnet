using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace Options.Validation.Features;

/// <summary>
/// A representation of a "feature" options object.
/// </summary>
[OptionsValidator]
public sealed partial record class FeatureOptions 
    : IValidateOptions<FeatureOptions>
{
    /// <summary>
    /// Gets or sets whether the feature is enabled.
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// Gets or sets the name of the feature.
    /// </summary>
    [MaxLength(
        length: 100, 
        ErrorMessage = "The name cannot be longer than 100 characters.")]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the version of the feature.
    /// </summary>
    [RegularExpression(
        pattern: @"^\d+(\.\d+){1,3}$",
        ErrorMessage = "The version input doesn't match the regex.")]
    public string? Version { get; set; }

    /// <summary>
    /// Gets or sets the endpoint (<see cref="Uri"/>) of the feature.
    /// </summary>
    public Uri? Endpoint { get; set; }

    /// <summary>
    /// Gets or sets the API key of the feature.
    /// </summary>
    [Key]
    public string? ApiKey { get; set; }

    /// <summary>
    /// Gets or sets any tags for the feature.
    /// </summary>
    [DeniedValues(
        values: [
            "deprecated",
            "out-of-date"
    ])]
    public string[] Tags { get; set; } = [];
}