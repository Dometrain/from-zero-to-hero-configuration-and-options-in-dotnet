namespace Options.Api.Logging;

/// <summary>
/// A <see cref="Dictionary{TKey, TValue}"/> where `TKey` is the logging category
/// or namespace/object name used to log at a certain log-level.
/// </summary>
/// <remarks>
/// The <see langword="string"/> value is case-insensitive
/// (<see cref="StringComparer.OrdinalIgnoreCase"/>).
/// </remarks>
public sealed class LogLevelOptions
    : Dictionary<string, LogLevel>
{
    /// <inheritdoc cref="Dictionary{TKey, TValue}" />
    public LogLevelOptions()
        : base(StringComparer.OrdinalIgnoreCase)
    {
    }
}
