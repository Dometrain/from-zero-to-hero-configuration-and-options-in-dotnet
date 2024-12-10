# Service Lifetime Reminder

- **Transient**: Created anew each time they're requested.
- **Scoped**: Created anew for a single scope as needed.
- **Singleton**: Created only once for the life of the app.

## Options Interfaces

- `IOptions<TOptions>`:

  - Singleton service lifetime.
  - Only read once, at app startup.

- `IOptionsSnapshot<TOptions>`:

  - Scoped service lifetime.
  - Values are recomputed for each new scope.
  - Designed for transient and scoped dependencies.

- `IOptionsMonitor<TOptions>`:

  - Singleton service lifetime.
  - Enables change detection.
  - Supports dynamic reloading of values.

## Monitoring Limitations

1. Limited to File-System Configuration Providers:

   - Microsoft.Extensions.Configuration.Ini
   - Microsoft.Extensions.Configuration.Json
   - Microsoft.Extensions.Configuration.KeyPerFile
   - Microsoft.Extensions.Configuration.UserSecrets
   - Microsoft.Extensions.Configuration.Xml

2. Some environments, such as File Shares or Docker Containers
  are unreliable for change notifications.

   - Set `DOTNET_USE_POLLING_FILE_WATCHER` to `true` for polling
