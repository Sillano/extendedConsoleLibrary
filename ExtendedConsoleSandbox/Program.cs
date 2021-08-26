using System;
using System.Runtime.InteropServices;
using System.Threading;
using ExtendedConsoleLibrary;

namespace ExtendedConsoleSandbox
{
    using ExtendedConsoleLibrary.ChooseTerminals;

    public static class Input
    {
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT point);

        public struct POINT
        {
            public int x;
            public int y;
        }

        public static POINT GetMousePosition()
        {
            POINT pos;
            GetCursorPos(out pos);
            return pos;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var values = new string[] { "Bartek", "Krzysiek", "Przemek", "Sebastian", "Radek" };

            var chooseTerminal = new SelectionChooseTerminal<string>(values);

            while (true)
            {
                var value = chooseTerminal.Choose();

                Console.WriteLine(value);

                Thread.Sleep(2000);
            }
        }
    }
}
