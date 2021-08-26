namespace ExtendedConsoleLibrary
{
    using System;

    public class ConsoleValue
    {
        public ConsoleValue() => this.cursorPosition = ExtendedConsole.CursorPosition;

        public ConsoleValue(string value) : base() => this.currentValue = value;

        private readonly (int, int) cursorPosition;

        private string currentValue = string.Empty;

        public void UpdateValue(object value) => this.UpdateValue(value.ToString());

        public void UpdateValue(string value)
        {
            lock (ExtendedConsole.ConsoleSynchronizer)
            {
                var storedCursorPosition = ExtendedConsole.CursorPosition;

                ExtendedConsole.CursorPosition = this.cursorPosition;

                foreach (var character in value) Console.Write(character);

                for (var i = 0; i < this.currentValue.Length - value.Length; i++) Console.Write(' ');

                this.currentValue = value;

                ExtendedConsole.CursorPosition = storedCursorPosition;
            }
        }

        public void InvertColors()
        {
            lock (ExtendedConsole.ConsoleSynchronizer)
            {
                var storedCursorPosition = ExtendedConsole.CursorPosition;

                ExtendedConsole.CursorPosition = this.cursorPosition;

                ExtendedConsole.WriteInverted(this.currentValue);

                ExtendedConsole.CursorPosition = storedCursorPosition;
            }
        }

        public static implicit operator ConsoleValue(string value) => new (value);
    }
}