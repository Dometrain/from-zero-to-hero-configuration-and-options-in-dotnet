using Microsoft.Extensions.Configuration;

namespace DomeTrain.FromZeroToHero.Configuration.Yaml;

/// <summary>
/// A YAML file-based <see cref="FileConfigurationProvider"/>.
/// </summary>
/// <remarks>
/// Initializes a new instance with the specified <paramref name="source"/>.
/// </remarks>
/// <param name="source">The YAML configuration source.</param>
public sealed class YamlConfigurationProvider(
    YamlConfigurationSource source) : FileConfigurationProvider(source)
{
    /// <summary>
    /// Loads the YAML data from a stream.
    /// </summary>
    /// <param name="stream">The stream to read.</param>
    public override void Load(Stream stream)
    {
        try
        {
            Data = YamlConfigurationFileParser.Parse(stream);
        }
        catch (Exception ex)
        {
            throw new FormatException(
                "Unable to parse YAML.", ex);
        }
    }
}
