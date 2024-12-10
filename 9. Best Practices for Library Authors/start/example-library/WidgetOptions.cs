using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace Example.Library;

[OptionsValidator]
public sealed partial class WidgetOptions : IValidateOptions<WidgetOptions>
{
    [Url, Required(AllowEmptyStrings = false)]
    public string? ImageUrl { get; set; }

    [AllowedValues(["Red", "Green", "Blue"])]
    public string Color { get; set; } = "Blue";

    public int Size { get; set; } = 10;

    public bool IsEnabled { get; set; } = true;

    public double Opacity { get; set; } = 1.0;
}
