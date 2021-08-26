using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendedConsoleLibrary
{
    public static class ExtendedConsole
    {
        public static object ConsoleSynchronizer { get; set; } = new object();

        public static void InvertColors() => (Console.ForegroundColor, Console.BackgroundColor) = (Console.BackgroundColor, Console.ForegroundColor);

        public static void WriteInverted(string text)
        {
            InvertColors();
            Console.Write(text);
            InvertColors();
        }

        public static (int, int) CursorPosition
        {
            get => (Console.CursorLeft, Console.CursorTop);
            set => (Console.CursorLeft, Console.CursorTop) = value;
        }
    }
}
