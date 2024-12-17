# From Zero to Hero: Configuration and Options in .NET

Welcome to the ["From Zero to Hero: Configuration and Options in .NET"](https://dometrain.com/course/from-zero-to-hero-configuration-and-options-in-dotnet/?ref=github) course on Dometrain! This course is designed to take you from a beginner to an expert in configuring and managing options in .NET applications. The repository contains the source code for the course, which you can use to follow along with the lessons.

## The Course

To get started with the course, visit the course page on Dometrain:

[![From Zero to Hero: Configuration and Options in .NET](media/configuration-and-options-in-dotnet.jpg)](https://dometrain.com/course/from-zero-to-hero-configuration-and-options-in-dotnet/?ref=github)

Each module in the course is represented by a folder in the repository. The folder contains the source code for the module, containing both a `/start` and `/end` directory—which aligns with the source code at a point in time as it relates to the course.

## Course Content

In this course, you will learn how to effectively use configuration and options in .NET to build robust and maintainable applications. Te course is divided into ten modules, each covering a different aspect of configuration and options in .NET. Here is an overview of the modules:

### 1. Course Overview

- Welcome
- What will you learn in this course?
- Who is the course for and prerequisites

### 2. Introduction to Configuration

- Introduction
- What is Configuration?
- Why configuration is important?
- Configuration in .NET
- Configuration sources & providers
- First Configuration NuGet package
- Explore the IConfiguration and related APIs
- Section Recap

### 3. Getting started with Configuration

- Introduction
- Standalone vs. Host
- What's a `ConfigurationManager`?
- Exploring the Worker Service default configuration
- Running the Worker Service with template behavior
- Learning the JSON configuration provider capabilities
- Environment specific configuration
- Configuring and manually parsing custom values
- Benefiting from the Binder package
- Section Recap

### 4. Configuration Providers

- Introduction to Configuration Providers
- Base File Providers
- Discussing the empty application builder sample app
- JSON configuration provider
- XML configuration provider
- INI configuration provider
- User Secrets configuration provider
- Managing user secrets
- Environment Variables configuration provider
- Command-line configuration provider
- Key-per file configuration provider
- Azure Key Vault configuration provider
- Azure App Configuration provider with Key Vault secrets
- Section Recap

### 5. Implementing a Custom Configuration Provider

- Introduction to Implementing a Custom Configuration Provider
- Create the implementation class library
- Implement the `IConfigurationSource`
- Implement the `IConfigurationProvider`
- Extend `IConfigurationBuilder` and expose `AddYamlFile` APIs
- Implementing the YAML parser
- Review and Finalize implementation details
- Consuming YAML configuration with custom provider
- Section Recap

### 6. Exploring the Options Pattern

- Introduction to the Options Pattern
- Modeling the Logging Options
- Bind Logging Options to Configuration
- Consuming Logging Options through DI
- Adding another options-modeled object
- Binding additional named-options
- Configuring and editing named-options
- Resolving named-options by name
- Verifying configuration bindings and DI hydration
- Considering alternative APIs for registering options
- Overriding configurations with post configure APIs
- Overriding all config-bound instances
- Avoid implementing `IOptions<T>`
- Understanding reflection-based binding
- Enabling source-generated configuration binding
- Section Recap

### 7. Options Pattern Validation

- Introduction to Validating Options
- Implementing the `IValidateOptions<TOptions>` interface
- Registering options with validation
- Using data-annotations for declarative validation
- Handling validation errors
- Expressing simple delegate-based validation with fluent APIs
- Controlling when validation errors occur
- Compile-time validation with source-generators
- Section Recap

### 8. Optioning Monitoring

- Introduction to Options Monitoring
- Differentiating `Options` interfaces
- Visualizing an Alerting App Scenario
- Exploring the Alerting Implementation
- Post Code-walk: `Options` and Settings
- Changing Config Data & Monitoring Alerts
- Being Mindful of Monitoring Limitations
- Section Recap

### 9. Best Practices for Library Authors

- Introduction to Consumer-Centric (Empathy-based) Authoring
- Defining Strongly-typed `WidgetOptions`
- Debating namespace Naming: `IServiceCollection` Extensions
- Exploring an `Add*` with `IConfigurationSection` API
- Consuming the `Add*` with `IConfigurationSection`
- Improving consumer experiences through meaningful error messages
- Confirming new consumer experiences
- Considerations when accepting Option-types as `Add*` API parameters
- Consuming the `Add*` with Options-type API
- Exposing an `Action<WidgetOptions>` API
- The Importance of Consistent APIs
- Using the `configureOptions` delegate-based API
- Section Recap

### 10. Course Conclusion

- Conclusion

## About the Instructor

[David Pine](https://davidpine.net) works in Developer Relations at Microsoft, focusing on .NET and Azure developer content. He is recognized as a [Google Developer Expert in Web Technologies](https://developers.google.com/profile/u/davidpine). David is the O'Reilly Media author of "Learning Blazor: Build Single-Page Apps with WebAssembly and C#". David focuses on the developer community, actively seeking opportunities to share knowledge through speaking engagements around the world. [David advocates for open-source](https://github.com/IEvagenlist), the .NET Foundation, C#, TypeScript, SignalR, Reactive Extensions, Azure and .NET. He's a co-host of the On .NET Live stream, part of the .NET Live TV family of streaming shows.

---

Happy learning!

The Dometrain Team
