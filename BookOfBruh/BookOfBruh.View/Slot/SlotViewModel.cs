﻿namespace BookOfBruh.View.Slot
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Media;
    using Core.GameData;
    using Core.SlotAnalysation;
    using Core.Symbols;
    using Infrastructure;
    using Infrastructure.EventArgs;
    using Color = System.Drawing.Color;

    public class SlotViewModel : NotifyPropertyChangedBase
    {
        public SlotViewModel()
        {
            Color[,] colors = GenerateCompletelyTransparentArray();
            this.SetSymbolColors(colors);
        }

        public EventHandler<WinEventArgs> FinishedSpinning;

        public string Symbol00 { get; private set; }
        public string Symbol10 { get; private set; }
        public string Symbol20 { get; private set; }
        public string Symbol30 { get; private set; }
        public string Symbol40 { get; private set; }

        public string Symbol01 { get; private set; }
        public string Symbol11 { get; private set; }
        public string Symbol21 { get; private set; }
        public string Symbol31 { get; private set; }
        public string Symbol41 { get; private set; }

        public string Symbol02 { get; private set; }
        public string Symbol12 { get; private set; }
        public string Symbol22 { get; private set; }
        public string Symbol32 { get; private set; }
        public string Symbol42 { get; private set; }


        public Brush Symbol00Color { get; private set; }
        public Brush Symbol10Color { get; private set; }
        public Brush Symbol20Color { get; private set; }
        public Brush Symbol30Color { get; private set; }
        public Brush Symbol40Color { get; private set; }

        public Brush Symbol01Color { get; private set; }
        public Brush Symbol11Color { get; private set; }
        public Brush Symbol21Color { get; private set; }
        public Brush Symbol31Color { get; private set; }
        public Brush Symbol41Color { get; private set; }

        public Brush Symbol02Color { get; private set; }
        public Brush Symbol12Color { get; private set; }
        public Brush Symbol22Color { get; private set; }
        public Brush Symbol32Color { get; private set; }
        public Brush Symbol42Color { get; private set; }
        

        public async Task RenderSpin(SpinResult spinResult)
        {
            this.ResetSlots();

            await this.RenderSpinningSymbols();

            await this.RenderCorrectSymbols(spinResult.Slots);

            this.RenderPattern(spinResult.Patterns);

            this.FinishedSpinning?.Invoke(this, new WinEventArgs(spinResult.BruhCoins));
        }

        private void ResetSlots()
        {
            Color[,] colors = GenerateCompletelyTransparentArray();
            this.SetSymbolColors(colors);
        }

        private async Task RenderSpinningSymbols()
        {
            const int millisecondsDelay = 20;

            this.Symbol00 = GetSpinningSymbol();
            this.Symbol10 = await RenderSpinningSymbol(millisecondsDelay);
            this.Symbol20 = await RenderSpinningSymbol(millisecondsDelay);
            this.Symbol30 = await RenderSpinningSymbol(millisecondsDelay);
            this.Symbol40 = await RenderSpinningSymbol(millisecondsDelay);

            this.Symbol01 = await RenderSpinningSymbol(millisecondsDelay);
            this.Symbol11 = await RenderSpinningSymbol(millisecondsDelay);
            this.Symbol21 = await RenderSpinningSymbol(millisecondsDelay);
            this.Symbol31 = await RenderSpinningSymbol(millisecondsDelay);
            this.Symbol41 = await RenderSpinningSymbol(millisecondsDelay);

            this.Symbol02 = await RenderSpinningSymbol(millisecondsDelay);
            this.Symbol12 = await RenderSpinningSymbol(millisecondsDelay);
            this.Symbol22 = await RenderSpinningSymbol(millisecondsDelay);
            this.Symbol32 = await RenderSpinningSymbol(millisecondsDelay);
            this.Symbol42 = await RenderSpinningSymbol(millisecondsDelay);
        }

        private static async Task<string> RenderSpinningSymbol(int delay)
        {
            await Task.Delay(delay);
            return GetSpinningSymbol();
        }

        private async Task RenderCorrectSymbols(Slots slots)
        {
            const int millisecondsDelay = 100;

            this.Symbol00 = await RenderCorrectSymbol(slots.Symbols[0, 0], millisecondsDelay);
            this.Symbol10 = await RenderCorrectSymbol(slots.Symbols[1, 0], millisecondsDelay);
            this.Symbol20 = await RenderCorrectSymbol(slots.Symbols[2, 0], millisecondsDelay);
            this.Symbol30 = await RenderCorrectSymbol(slots.Symbols[3, 0], millisecondsDelay);
            this.Symbol40 = await RenderCorrectSymbol(slots.Symbols[4, 0], millisecondsDelay);

            this.Symbol01 = await RenderCorrectSymbol(slots.Symbols[0, 1], millisecondsDelay);
            this.Symbol11 = await RenderCorrectSymbol(slots.Symbols[1, 1], millisecondsDelay);
            this.Symbol21 = await RenderCorrectSymbol(slots.Symbols[2, 1], millisecondsDelay);
            this.Symbol31 = await RenderCorrectSymbol(slots.Symbols[3, 1], millisecondsDelay);
            this.Symbol41 = await RenderCorrectSymbol(slots.Symbols[4, 1], millisecondsDelay);

            this.Symbol02 = await RenderCorrectSymbol(slots.Symbols[0, 2], millisecondsDelay);
            this.Symbol12 = await RenderCorrectSymbol(slots.Symbols[1, 2], millisecondsDelay);
            this.Symbol22 = await RenderCorrectSymbol(slots.Symbols[2, 2], millisecondsDelay);
            this.Symbol32 = await RenderCorrectSymbol(slots.Symbols[3, 2], millisecondsDelay);
            this.Symbol42 = await RenderCorrectSymbol(slots.Symbols[4, 2], millisecondsDelay);

        }

        private static async Task<string> RenderCorrectSymbol(ISymbol symbol, int delay)
        {
            await Task.Delay(delay);
            return SymbolToPath(symbol);
        }


        private void RenderPattern(List<Pattern> patterns)
        {
            Color[,] colors = CalculateNewColors(patterns);
            this.SetSymbolColors(colors);
        }

        private void SetSymbolColors(Color[,] colors)
        {
            this.Symbol00Color = ColorToBrush(colors[0, 0]);
            this.Symbol10Color = ColorToBrush(colors[1, 0]);
            this.Symbol20Color = ColorToBrush(colors[2, 0]);
            this.Symbol30Color = ColorToBrush(colors[3, 0]);
            this.Symbol40Color = ColorToBrush(colors[4, 0]);

            this.Symbol01Color = ColorToBrush(colors[0, 1]);
            this.Symbol11Color = ColorToBrush(colors[1, 1]);
            this.Symbol21Color = ColorToBrush(colors[2, 1]);
            this.Symbol31Color = ColorToBrush(colors[3, 1]);
            this.Symbol41Color = ColorToBrush(colors[4, 1]);

            this.Symbol02Color = ColorToBrush(colors[0, 2]);
            this.Symbol12Color = ColorToBrush(colors[1, 2]);
            this.Symbol22Color = ColorToBrush(colors[2, 2]);
            this.Symbol32Color = ColorToBrush(colors[3, 2]);
            this.Symbol42Color = ColorToBrush(colors[4, 2]);
        }

        private static Color[,] CalculateNewColors(List<Pattern> patterns)
        {
            Color[,] colors = GenerateCompletelyTransparentArray();
            foreach (Point point in patterns.SelectMany(pattern => pattern.Value))
            {
                colors[point.X, point.Y] = Color.BlueViolet;
            }

            return colors;
        }

        private static Color[,] GenerateCompletelyTransparentArray()
        {
            return new Color[,]
            {
                { Color.Transparent, Color.Transparent, Color.Transparent },
                { Color.Transparent, Color.Transparent, Color.Transparent },
                { Color.Transparent, Color.Transparent, Color.Transparent },
                { Color.Transparent, Color.Transparent, Color.Transparent },
                { Color.Transparent, Color.Transparent, Color.Transparent }
            };
        }

        private static string GetSpinningSymbol()
        {
            return $"pack://application:,,,/BookOfBruh.View;component/Images/Spinning.gif";
        }

        private static string SymbolToPath(ISymbol symbol)
        {
            string symbolName = symbol?.GetType().Name;
            return $"pack://application:,,,/BookOfBruh.View;component/Images/{symbolName}.png";
        }

        private static Brush ColorToBrush(Color color)
        {
            System.Windows.Media.Color mediaColor = new()
            {
                A = color.A,
                B = color.B,
                R = color.R,
                G = color.G
            };
            return new SolidColorBrush(mediaColor);
        }
    }
}
