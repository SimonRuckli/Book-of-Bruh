namespace BookOfBruh.View.AcceptanceTest.Infrastructure
{
    using Core.GameData;
    using Core.SlotGeneration;
    using Core.Symbols;

    public class FakeSlotGenerator : ISlotGenerator
    {
        public Slots Generate()
        {
            return new Slots(new ISymbol[,]
            {
                {new TenSymbol(), new ASymbol(), new ASymbol()},
                {new TenSymbol(), new JSymbol(), new JSymbol()},
                {new TenSymbol(), new JSymbol(), new JSymbol()},
                {new ASymbol(), new ASymbol(), new JSymbol()},
                {new ASymbol(), new ASymbol(), new JSymbol()},
            });
        }
    }
}
