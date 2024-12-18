using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TimeCheckerClasses;
public struct MainFormAttrs {

    public Size Size { get; set; } = new Size(264, 167);
    public Point Point { get; set; } = new Point(200, 300);

    public MainFormAttrs() { }

    [JsonConstructor]
    public MainFormAttrs(Size size, Point point) {
        Size = size;
        Point = point;
    }

    public static void Save(MainFormAttrs mainFormAttrs) {
        string json = JsonSerializer.Serialize(mainFormAttrs, new JsonSerializerOptions {
            WriteIndented = true
        });
        File.WriteAllText("main-form-attrs.json", json);
    }

    public static MainFormAttrs Load() {
        if (!File.Exists("main-form-attrs.json")) return new();

        try {
            string json = File.ReadAllText("main-form-attrs.json");
            return JsonSerializer.Deserialize<MainFormAttrs>(json);
        } catch {
            return new();
        }
    }
}
