using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TimeCheckerClasses;
public struct MenuAttrs {
    public bool PrintDate { get; set; } = false;
    public bool Bold {
        get => Font.Bold;
        set => Font = new Font(Font.FontFamily, Font.Size, value ? FontStyle.Bold : FontStyle.Regular);
    }
    public Font Font { get; set; } = new("Segoe UI", 20f);
    public float FontSize {
        get => Font.Size;
        set => Font = new Font(Font.FontFamily, value, Bold ? FontStyle.Bold : FontStyle.Regular);
    }

    public MenuAttrs() { }
    public MenuAttrs(bool printDate, Font font) {
        PrintDate = printDate;
        Font = font;
    }
}
