using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TimeCheckerClasses;
public struct MenuAttrs : ICloneable {
    public bool PrintDate { get; set; } = false;
    public Font Font { get; set; } = new("Segoe UI", 20f);
    public RepeatFreq RepeatFreq { get; set; } = RepeatFreq.FiveMinutes;
    public int WaitTime {
        get => _waitTime;
        set {
            if (value < 0 || value > 4) throw new ArgumentOutOfRangeException(nameof(WaitTime));
            _waitTime = value;
        }
    }

    private int _waitTime = 1;

    public int RepeatFreqIndex => RepeatFreq switch {
        RepeatFreq.FiveMinutes => 0,
        RepeatFreq.FiveteenMinutes => 1,
        RepeatFreq.HalfAnHour => 2,
        RepeatFreq.Hour => 3,
        RepeatFreq.FourHours => 4,
        _ => throw new NotImplementedException()
    };
    
    public MenuAttrs() { }
    public MenuAttrs(bool printDate, Font font, RepeatFreq repeatFreq, int waitTime) {
        if (waitTime < 0 || waitTime > 3) throw new ArgumentOutOfRangeException(nameof(WaitTime));

        PrintDate = printDate;
        Font = font;
        RepeatFreq = repeatFreq;
        WaitTime = waitTime;
    }

    public object Clone() => new MenuAttrs(PrintDate, Font, RepeatFreq, WaitTime);
}

public enum RepeatFreq : int {
    FiveMinutes = 5,
    FiveteenMinutes = 15,
    HalfAnHour = 30,
    Hour = 60,
    FourHours = 240
}
