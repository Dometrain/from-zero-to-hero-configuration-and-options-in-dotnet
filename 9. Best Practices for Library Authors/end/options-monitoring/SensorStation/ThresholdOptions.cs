using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace Options.Monitoring.SensorStation;

[OptionsValidator]
public sealed partial record class ThresholdOptions 
    : IValidateOptions<ThresholdOptions>
{
    /// <summary>
    /// Gets or sets the low threshold.
    /// </summary>
    [Range(
        minimum: -0.001d, 
        maximum: +1.000d)]
    [Required(ErrorMessage = """
        A low threshold value is required
        """)]
    public double Low { get; set; }

    /// <summary>
    /// Gets or sets the high threshold.
    /// </summary>
    [Range(
        minimum: +1d,
        maximum: +5d)]
    [Required(ErrorMessage = """
        A high threshold value is required
        """)]
    public double High { get; set; }
}
