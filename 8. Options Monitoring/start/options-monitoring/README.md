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
