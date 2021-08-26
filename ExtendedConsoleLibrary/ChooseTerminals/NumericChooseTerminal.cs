namespace ExtendedConsoleLibrary.ChooseTerminals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NumericChooseTerminal<T> : ChooseTerminal<T, string>
    {
        public NumericChooseTerminal(IEnumerable<T> objects) : base(objects)
        {
        }

        public NumericChooseTerminal(IEnumerable<T> objects, IEnumerable<string> names) : base(objects, names)
        {
        }

        public override T Choose()
        {
            var index = string.Empty;

            while (true)
            {
                this.DrawTerminal(index);

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Backspace:
                        if (string.IsNullOrEmpty(index))
                            break;
                        index = index.Substring(0, index.Length - 1);
                        break;
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        index += 0;
                        break;
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        index += 1;
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        index += 2;
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        index += 3;
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        index += 4;
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        index += 5;
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        index += 6;
                        break;
                    case ConsoleKey.D7:
                    case ConsoleKey.NumPad7:
                        index += 7;
                        break;
                    case ConsoleKey.D8:
                    case ConsoleKey.NumPad8:
                        index += 8;
                        break;
                    case ConsoleKey.D9:
                    case ConsoleKey.NumPad9:
                        index += 9;
                        break;
                    case ConsoleKey.Escape:
                        throw new AbortedChooseTerminalException();
                    default:
                        break;
                }

                if (this.CountDigits(this.MaxIndex) != index.Length) continue;

                var intIndex = int.Parse(index);

                if (intIndex <= this.MaxIndex && intIndex > 0)
                {
                    Console.Clear();
                    return this.Objects[intIndex - 1];
                }

                index = index[..^1];
            }
        }

        protected override void DrawTerminal(string index)
        {
            Console.Clear();

            Console.WriteLine("Wybierz element:");

            for (var i = 0; i < this.Names.Count(); i++)
            {
                var visibleI = (i + 1).ToString("D" + this.CountDigits(this.MaxIndex));

                if (string.IsNullOrEmpty(index) || visibleI.StartsWith(index))
                    Console.WriteLine($"{visibleI}: {this.Names[i]}");
            }

            Console.Write($"\nPodaj kolejny znak: {index}".PadLeft(20, '-'));
        }

        private int CountDigits(int number) => number / 10 == 0 ? 1 : 1 + this.CountDigits(number / 10);
    }
}
