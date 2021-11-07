﻿using BookOfBruh.Core.Slot;
using CSharpFunctionalExtensions;

namespace BookOfBruh.Core
{
    using System;
    using Code;

    public class Game
    {
        private readonly Player player;
        private readonly CodeValidator codeValidator;
        private readonly SlotGenerator slotGenerator;
        private readonly SlotAnalyzer slotAnalyzer;


        public Game(Player player, CodeValidator codeValidator, SlotGenerator slotGenerator, SlotAnalyzer slotAnalyzer)
        {
            this.player = player;
            this.codeValidator = codeValidator;
            this.slotGenerator = slotGenerator;
            this.slotAnalyzer = slotAnalyzer;
        }

        public Result<SpinResult> Spin(double stake)
        {
            throw new NotImplementedException();
        }

        public Result<double> AddToWallet(int code)
        {
            throw new NotImplementedException();
        }
    }
}
