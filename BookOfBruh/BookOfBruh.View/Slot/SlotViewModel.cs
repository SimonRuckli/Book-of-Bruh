namespace BookOfBruh.View.Slot
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
        private readonly ISlotSpinner slotSpinner;

        public SlotViewModel(ISlotSpinner slotSpinner)
        {
            this.slotSpinner = slotSpinner;
            this.Slot00 = new Slot(string.Empty, ColorToBrush(Color.Transparent));
            this.Slot10 = new Slot(string.Empty, ColorToBrush(Color.Transparent));
            this.Slot20 = new Slot(string.Empty, ColorToBrush(Color.Transparent));
            this.Slot30 = new Slot(string.Empty, ColorToBrush(Color.Transparent));
            this.Slot40 = new Slot(string.Empty, ColorToBrush(Color.Transparent));

            this.Slot01 = new Slot(string.Empty, ColorToBrush(Color.Transparent));
            this.Slot11 = new Slot(string.Empty, ColorToBrush(Color.Transparent));
            this.Slot21 = new Slot(string.Empty, ColorToBrush(Color.Transparent));
            this.Slot31 = new Slot(string.Empty, ColorToBrush(Color.Transparent));
            this.Slot41 = new Slot(string.Empty, ColorToBrush(Color.Transparent));

            this.Slot02 = new Slot(string.Empty, ColorToBrush(Color.Transparent));
            this.Slot12 = new Slot(string.Empty, ColorToBrush(Color.Transparent));
            this.Slot22 = new Slot(string.Empty, ColorToBrush(Color.Transparent));
            this.Slot32 = new Slot(string.Empty, ColorToBrush(Color.Transparent));
            this.Slot42 = new Slot(string.Empty, ColorToBrush(Color.Transparent));
        }

        public EventHandler<WinEventArgs> FinishedSpinning;

        public Slot Slot00 { get; private set; }
        public Slot Slot10 { get; private set; }
        public Slot Slot20 { get; private set; }
        public Slot Slot30 { get; private set; }
        public Slot Slot40 { get; private set; }

        public Slot Slot01 { get; private set; }
        public Slot Slot11 { get; private set; }
        public Slot Slot21 { get; private set; }
        public Slot Slot31 { get; private set; }
        public Slot Slot41 { get; private set; }

        public Slot Slot02 { get; private set; }
        public Slot Slot12 { get; private set; }
        public Slot Slot22 { get; private set; }
        public Slot Slot32 { get; private set; }
        public Slot Slot42 { get; private set; }


        public async Task RenderSpin(SpinResult spinResult)
        {
            this.ResetSlots();

            await this.SpinSymbols(spinResult.Slots.Symbols);

            this.RenderPattern(spinResult.Patterns);

            this.FinishedSpinning?.Invoke(this, new WinEventArgs(spinResult.BruhCoins));
        }

        private async Task SpinSymbols(ISymbol[,] symbols)
        { 
            await foreach(ISymbol symbol in slotSpinner.GenerateSpinSymbols(100,100,symbols[0,0]))
            {
                this.Slot00 = new Slot(SymbolToPath(symbol), Slot00.Color);
            };
        }
        
        private void ResetSlots()
        {
            Color[,] colors = GenerateCompletelyTransparentArray();
            this.SetSymbolColors(colors);
        }
        
        private void RenderPattern(List<Pattern> patterns)
        {
            Color[,] colors = CalculateNewColors(patterns);
            this.SetSymbolColors(colors);
        }

        private void SetSymbolColors(Color[,] colors)
        {
            this.Slot00 = new Slot(Slot00.Symbol, ColorToBrush(colors[0, 0]));
            this.Slot10 = new Slot(Slot10.Symbol, ColorToBrush(colors[1, 0]));
            this.Slot20 = new Slot(Slot20.Symbol, ColorToBrush(colors[2, 0]));
            this.Slot30 = new Slot(Slot30.Symbol, ColorToBrush(colors[3, 0]));
            this.Slot40 = new Slot(Slot40.Symbol, ColorToBrush(colors[4, 0]));
                                                                            
            this.Slot01 = new Slot(Slot01.Symbol, ColorToBrush(colors[0, 1]));
            this.Slot11 = new Slot(Slot11.Symbol, ColorToBrush(colors[1, 1]));
            this.Slot21 = new Slot(Slot21.Symbol, ColorToBrush(colors[2, 1]));
            this.Slot31 = new Slot(Slot31.Symbol, ColorToBrush(colors[3, 1]));
            this.Slot41 = new Slot(Slot41.Symbol, ColorToBrush(colors[4, 1]));
                                                                            
            this.Slot02 = new Slot(Slot02.Symbol, ColorToBrush(colors[0, 2]));
            this.Slot12 = new Slot(Slot12.Symbol, ColorToBrush(colors[1, 2]));
            this.Slot22 = new Slot(Slot22.Symbol, ColorToBrush(colors[2, 2]));
            this.Slot32 = new Slot(Slot32.Symbol, ColorToBrush(colors[3, 2]));
            this.Slot42 = new Slot(Slot40.Symbol, ColorToBrush(colors[4, 2]));
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
