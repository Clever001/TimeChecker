using System;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TimeCheckerClasses;
public struct MenuAttrs : ICloneable {
    public bool PrintDate { get; set; } = false;
    [JsonIgnore]
    public Color Color { get; set; } = Color.LightSteelBlue;
    public int SerializableColor {
        get => Color.ToArgb();
        set => Color = Color.FromArgb(value);
    }
    [JsonIgnore]
    public Font Font { get; set; } = new("Segoe UI", 20f);
    public SerializableFont SerializableFont {
        get => new(Font);
        set => Font = value.ToFont();
    }
    public RepeatFreq RepeatFreq { get; set; } = RepeatFreq.FiveMinutes;
    public int WaitTime {
        get => _waitTime;
        set {
            if (value < 0 || value > 4) throw new ArgumentOutOfRangeException(nameof(WaitTime));
            _waitTime = value;
        }
    }
    [JsonIgnore]
    private int _waitTime = 1;

    [JsonIgnore]
    public int RepeatFreqIndex => RepeatFreq switch {
        RepeatFreq.FiveMinutes => 0,
        RepeatFreq.FiveteenMinutes => 1,
        RepeatFreq.HalfAnHour => 2,
        RepeatFreq.Hour => 3,
        RepeatFreq.FourHours => 4,
        _ => throw new NotImplementedException()
    };
    
    public MenuAttrs() { }
    [JsonConstructor]
    public MenuAttrs(bool printDate, Color color, Font font, RepeatFreq repeatFreq, int waitTime) {
        if (waitTime < 0 || waitTime > 4) throw new ArgumentOutOfRangeException(nameof(WaitTime));

        PrintDate = printDate;
        Color = color;
        Font = font;
        RepeatFreq = repeatFreq;
        WaitTime = waitTime;
    }

    public object Clone() => new MenuAttrs(PrintDate, Color, Font, RepeatFreq, WaitTime);

    public static void Save(MenuAttrs menuAttrs) {
        string json = JsonSerializer.Serialize(menuAttrs, new JsonSerializerOptions {
            WriteIndented = true
        });
        File.WriteAllText("settings.json", json);
    }

    public static MenuAttrs Load() {
        if (!File.Exists("settings.json")) return new();

        try {
            string json = File.ReadAllText("settings.json");
            return JsonSerializer.Deserialize<MenuAttrs>(json);
        } catch {
            return new();
        }
    }
}

public enum RepeatFreq : int {
    FiveMinutes = 5,
    FiveteenMinutes = 15,
    HalfAnHour = 30,
    Hour = 60,
    FourHours = 240
}
