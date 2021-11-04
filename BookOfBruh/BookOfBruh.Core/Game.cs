namespace BookOfBruh.Core
{
    using System;
    using BookOfBruh.Core.Code;

    public class Game
    {
        private readonly SlotMachine slotMachine;
        private readonly Player player;
        private readonly CodeValidator codeValidator;

        public Game(SlotMachine slotMachine, Player player, CodeValidator codeValidator)
        {
            this.slotMachine = slotMachine;
            this.player = player;
            this.codeValidator = codeValidator;
        }

        public void Spin(double stake)
        {
            throw new NotImplementedException();
        }

        public void AddToWallet(int code)
        {
            throw new NotImplementedException();
        }
    }
}
