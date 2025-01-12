using System.Diagnostics.CodeAnalysis;
using Avalonia.Media;
using XamlMath.Colors;
using XamlMath.Rendering;
using IBrush = XamlMath.Rendering.IBrush;

namespace AvaloniaMath.Rendering;

internal record AvaloniaBrush : GenericBrush<Avalonia.Media.IBrush>
{
    private AvaloniaBrush(Avalonia.Media.IBrush brush) : base(brush) {}

    public static AvaloniaBrush FromBrush(Avalonia.Media.IBrush brush) => new(brush);

    public static AvaloniaBrush FromColor(RgbaColor value) =>
        new(
            new SolidColorBrush(
                Color.FromArgb(value.A, value.R, value.G, value.B)));
}

public static class AvaloniaBrushExtensions
{
    public static Avalonia.Media.IBrush? ToAvalonia(this IBrush? brush) =>
        ((AvaloniaBrush?)brush)?.Value;

    [return: NotNullIfNotNull(nameof(brush))]
    public static IBrush? ToPlatform(this Brush? brush) =>
        brush == null ? null : AvaloniaBrush.FromBrush(brush);
}

public class AvaloniaBrushFactory : IBrushFactory
{
    private AvaloniaBrushFactory() { }
    public static AvaloniaBrushFactory Instance { get; } = new();

    public IBrush FromColor(RgbaColor color) =>
        new SolidColorBrush(Color.FromArgb(color.A, color.R, color.G, color.B)).ToPlatform();
}
