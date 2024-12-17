using System;
using System.Drawing;
using System.Text.Json.Serialization;

public class SerializableFont {
    public string FontFamily { get; set; } = "Segoe UI";
    public float Size { get; set; } = 20f;
    public FontStyle Style { get; set; } = FontStyle.Regular;
    public GraphicsUnit Unit { get; set; } = GraphicsUnit.Point;

    [JsonConstructor]
    public SerializableFont(string fontFamily, float size, FontStyle style, GraphicsUnit unit) {
        FontFamily = fontFamily;
        Size = size;
        Style = style;
        Unit = unit;
    }

    public SerializableFont(Font font) {
        FontFamily = font.FontFamily.Name;
        Size = font.Size;
        Style = font.Style;
        Unit = font.Unit;
    }

    public Font ToFont() => new(FontFamily, Size, Style, Unit);
}
