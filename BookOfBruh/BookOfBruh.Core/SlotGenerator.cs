namespace BookOfBruh.Core
{
    using System;

    public class SlotGenerator
    {
        public Slots Generate()
        {
            return new Slots(new ISymbol[5, 3]);
        }
    }
}
