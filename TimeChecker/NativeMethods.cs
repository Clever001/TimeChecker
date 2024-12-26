using System;
using System.Runtime.InteropServices;

public static class NativeMethods {
    // Константы для WM_NCHITTEST
    public const int HTLEFT = 10;
    public const int HTRIGHT = 11;
    public const int HTTOP = 12;
    public const int HTTOPLEFT = 13;
    public const int HTTOPRIGHT = 14;
    public const int HTBOTTOM = 15;
    public const int HTBOTTOMLEFT = 16;
    public const int HTBOTTOMRIGHT = 17;

    // Константа для сообщения WM_NCHITTEST
    public const int WM_NCHITTEST = 0x0084;

    // Импорт функции Windows для работы с окнами
    [DllImport("user32.dll")]
    public static extern IntPtr DefWindowProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
}
