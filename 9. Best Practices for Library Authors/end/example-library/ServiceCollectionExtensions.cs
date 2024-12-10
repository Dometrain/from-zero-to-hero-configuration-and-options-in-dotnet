using Example.Library;
using Microsoft.Extensions.Configuration;

// There's some debate over this namespace!
namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Represents a set of extension methods on the 
/// <see cref="IServiceCollection"/> type for adding
/// "widget" services, and expects a configuration mapping
/// to the <see cref="WidgetOptions"/> object for DI.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds widget services to the given <paramref name="services"/> collection.
    /// Configures the given <paramref name="widgetConfigSection"/> to 
    /// the <see cref="WidgetOptions"/> object.
    /// <param name="services">
    /// The service collection to add services to.
    /// </param>
    /// <param name="widgetConfigSection">
    /// The widget configuration section to bind existing to.
    /// </param>
    /// <returns>
    /// The same <paramref name="services"/> instance with other services added.
    /// </returns>
    public static IServiceCollection AddWidgetServices(
        this IServiceCollection services,
        IConfigurationSection widgetConfigSection)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(widgetConfigSection);

        services.AddOptionsWithValidateOnStart<WidgetOptions>()
            .BindConfiguration(widgetConfigSection.Key)
            .ValidateDataAnnotations();

        // TODO:
        //   Add widget services to the service collection.

        return services;
    }

    /// <summary>
    /// Adds widget services to the given <paramref name="services"/> collection.
    /// Then add existing for the<see cref="WidgetOptions"/> type,
    /// and binds against the configuration with the <paramref name="configSectionPath"/>.
    /// <param name="services">
    /// The service collection to add services to.
    /// </param>
    /// <param name="configSectionPath">
    /// The widget configuration section to bind existing from.
    /// </param>
    /// <returns>
    /// The same <paramref name="services"/> instance with other services added.
    /// </returns>
    public static IServiceCollection AddWidgetServices(
        this IServiceCollection services,
        string configSectionPath)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configSectionPath);

        services.AddOptionsWithValidateOnStart<WidgetOptions>()
            .BindConfiguration(configSectionPath)
            .ValidateDataAnnotations();

        // TODO:
        //   Add widget services to the service collection.

        return services;
    }

    /// <summary>
    /// Adds widget services to the given <paramref name="services"/> collection.
    /// Post configures the <paramref name="widgetOptions"/> as the source of 
    /// truth, overriding all other previously configured values.
    /// <param name="services">
    /// The service collection to add services to.
    /// </param>
    /// <param name="widgetOptions">
    /// The widget existing instance to bind to.
    /// </param>
    /// <returns>
    /// The same <paramref name="services"/> instance with other services added.
    /// </returns>
    public static IServiceCollection AddWidgetServices(
        this IServiceCollection services,
        WidgetOptions widgetOptions)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(widgetOptions);

        // TODO:
        //   Determine if you want to use:
        //      .Configure(configureOptions);     // Runs before PostConfigure calls
        //   Or instead use:
        //      .PostConfigure(configureOptions); // Runs after all Configure calls

        services.AddOptionsWithValidateOnStart<WidgetOptions>()
            .PostConfigure(configureOptions: existing =>
            {
                // Overwrite existing values with
                // user provided values.
                existing.Color = widgetOptions.Color;
                existing.ImageUrl = widgetOptions.ImageUrl;
                existing.Opacity = widgetOptions.Opacity;
                existing.IsEnabled = widgetOptions.IsEnabled;
                existing.Size = widgetOptions.Size;
            })
            .ValidateDataAnnotations();

        // TODO:
        //   Add widget services to the service collection.

        return services;
    }

    /// <summary>
    /// Adds widget services to the given <paramref name="services"/> collection.
    /// Configures the <paramref name="configureOptions"/> to 
    /// the <see cref="WidgetOptions"/> object.
    /// <param name="services">
    /// The service collection to add services to.
    /// </param>
    /// <param name="configureOptions">
    /// The widget configuration section to bind existing from.
    /// </param>
    /// <returns>
    /// The same <paramref name="services"/> instance with other services added.
    /// </returns>
    public static IServiceCollection AddWidgetServices(
        this IServiceCollection services,
        Action<WidgetOptions> configureOptions)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configureOptions);

        // TODO:
        //   Determine if you want to use:
        //      .Configure(configureOptions);     // Runs before PostConfigure calls
        //   Or instead use:
        //      .PostConfigure(configureOptions); // Runs after all Configure calls

        services.AddOptionsWithValidateOnStart<WidgetOptions>()
            .Configure(configureOptions)
            .ValidateDataAnnotations();

        // TODO:
        //   Add widget services to the service collection.

        return services;
    }
}
