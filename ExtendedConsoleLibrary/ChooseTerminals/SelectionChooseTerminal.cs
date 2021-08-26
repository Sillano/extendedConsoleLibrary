namespace ExtendedConsoleLibrary.ChooseTerminals
{
    using System;
    using System.Collections.Generic;

    public class SelectionChooseTerminal<T> : ChooseTerminal<T, int>
    {
        private int Index
        {
            get => base.Index;
            set => base.Index = Math.Max(0, Math.Min(this.MaxIndex - 1, value));
        }


        public SelectionChooseTerminal(IEnumerable<T> objects) : base(objects)
        {
        }

        public SelectionChooseTerminal(IEnumerable<T> objects, IEnumerable<string> names) : base(objects, names)
        {
        }

        public override T Choose()
        {
            Console.CursorVisible = false;

            const int jump = 0;

            while (true)
            {
                this.DrawTerminal(this.Index);

                
            }
        }

        public override T Decide()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    this.Index--;
                    break;
                case ConsoleKey.DownArrow:
                    this.Index++;
                    break;
                case ConsoleKey.LeftArrow:
                    this.Index -= jump;
                    break;
                case ConsoleKey.RightArrow:
                    this.Index += jump;
                    break;
                case ConsoleKey.Escape:
                    throw new AbortedChooseTerminalException();
                case ConsoleKey.Enter:
                    Console.Clear();
                    Console.CursorVisible = true;
                    return this.Objects[this.Index];
                default:
                    break;
            }
        }

        protected override void DrawTerminal(int index)
        {
            Console.Clear();

            for(var i = 0; i < this.MaxIndex; i++)
            {
                var text = $"{this.Names[i]}\n";

                if(i != index)
                    Console.Write(text);
                else
                    ExtendedConsole.WriteInverted(text);
            }
        }
    }
}