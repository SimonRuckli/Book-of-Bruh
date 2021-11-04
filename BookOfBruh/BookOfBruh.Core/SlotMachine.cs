namespace BookOfBruh.Core
{
    using System;

    public class SlotMachine
    {
        private readonly SlotGenerator slotGenerator;
        private readonly SlotAnalyzer slotAnalyzer;

        public SlotMachine(SlotGenerator slotGenerator, SlotAnalyzer slotAnalyzer)
        {
            this.slotGenerator = slotGenerator;
            this.slotAnalyzer = slotAnalyzer;
        }

        public double Spin(double stake)
        {
            throw new NotImplementedException();
        }
    }
}
