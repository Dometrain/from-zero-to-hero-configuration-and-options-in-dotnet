namespace Options.Validation.Features;

internal static class FeatureOptionsValidators
{
    internal static (
        Func<FeatureOptions, bool> Validation,
        string FailureMessage
    ) EnabledWithMissingEndpoint => (
        Validation: static options =>
        {
            if (options is { Enabled: true, Endpoint: null })
            {
                return false;
            }

            return true;
        },
        FailureMessage: "The weather station cannot be enabled without a valid URI."
    );
}
