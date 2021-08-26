namespace ExtendedConsoleLibrary.ChooseTerminals
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class ChooseTerminal<TReturnedValue,TIndex>
    {
        protected readonly TReturnedValue[] Objects;

        protected readonly string[] Names;

        protected TIndex Index = default;

        protected int MaxIndex => this.Names.Count();

        protected ChooseTerminal(IEnumerable<TReturnedValue> objects) : this(objects, objects.Select(x => x.ToString()))
        {
            
        }

        protected ChooseTerminal(IEnumerable<TReturnedValue> objects, IEnumerable<string> names)
        {
            this.Objects = objects.ToArray();
            this.Names = names.ToArray();
        }

        public virtual TReturnedValue Choose()
        {
            this.DrawTerminal(this.Index);

            while (true)
            {

            }
        }

        public abstract TReturnedValue Decide();

        protected abstract void DrawTerminal(TIndex index);

        protected abstract void UpdateTerminal(TIndex index);
    }
}
