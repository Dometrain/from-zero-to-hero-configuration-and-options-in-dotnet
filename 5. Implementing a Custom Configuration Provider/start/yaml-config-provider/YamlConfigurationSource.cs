﻿using Microsoft.Extensions.Configuration;

namespace DomeTrain.FromZeroToHero.Configuration.Yaml;

/// <summary>
/// Represents a YAML file as an <see cref="IConfigurationSource"/>.
/// </summary>
public sealed class YamlConfigurationSource 
    : FileConfigurationSource
{
    /// <summary>
    /// Builds the <see cref="YamlConfigurationProvider"/> for this source.
    /// </summary>
    /// <param name="builder">The <see cref="IConfigurationBuilder"/>.</param>
    /// <returns>A <see cref="YamlConfigurationProvider"/></returns>
    public override IConfigurationProvider Build(
        IConfigurationBuilder builder)
    {
        return default!;
    }
}
