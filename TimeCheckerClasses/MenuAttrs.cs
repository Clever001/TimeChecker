using System;
using System.Collections.Generic;
using System.Text;

namespace TimeCheckerClasses;
public struct MenuAttrs {
    public bool PrintDate { get; set; } = false;
    public FontScale FontScale { get; set; } = FontScale.Medium;

    public MenuAttrs() { }
    public MenuAttrs(bool printDate, FontScale fontScale) {
        PrintDate = printDate;
        FontScale = fontScale;
    }
}

public enum FontScale : int {
    Small = 15, Medium = 20, Big = 25, Huge = 30
}
