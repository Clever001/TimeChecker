using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TimeCheckerClasses;
public struct MenuAttrs {
    public bool PrintDate { get; set; } = false;
    public bool Bold {
        get => Font.Bold;
    }
    public Font Font { get; set; } = new("Segoe UI", 20f);
    public float FontSize {
        get => Font.Size;
    }

    public MenuAttrs() { }
    public MenuAttrs(bool printDate, Font font) {
        PrintDate = printDate;
        Font = font;
    }
}
