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

            await this.SpinSymbols(spinResult.Slots.Symbols);

            this.RenderPattern(spinResult.Patterns);

            this.FinishedSpinning?.Invoke(this, new WinEventArgs(spinResult.BruhCoins));
        }

        private async Task SpinSymbols(ISymbol[,] symbols)
        {
            const int millisecondsDelay = 50;

            List<ISymbol> symbolList00 = GenerateSpinSymbols(20, symbols[0, 0]);
            List<ISymbol> symbolList01 = GenerateSpinSymbols(20, symbols[0, 1]);
            List<ISymbol> symbolList02 = GenerateSpinSymbols(20, symbols[0, 2]);
           
            List<ISymbol> symbolList10 = GenerateSpinSymbols(25, symbols[1, 0]);
            List<ISymbol> symbolList11 = GenerateSpinSymbols(25, symbols[1, 1]);
            List<ISymbol> symbolList12 = GenerateSpinSymbols(25, symbols[1, 2]);
           
            List<ISymbol> symbolList20 = GenerateSpinSymbols(30, symbols[2, 0]);
            List<ISymbol> symbolList21 = GenerateSpinSymbols(30, symbols[2, 1]);
            List<ISymbol> symbolList22 = GenerateSpinSymbols(30, symbols[2, 2]);
           
            List<ISymbol> symbolList30 = GenerateSpinSymbols(35, symbols[3, 0]);
            List<ISymbol> symbolList31 = GenerateSpinSymbols(35, symbols[3, 1]);
            List<ISymbol> symbolList32 = GenerateSpinSymbols(35, symbols[3, 2]);
           
            List<ISymbol> symbolList40 = GenerateSpinSymbols(40, symbols[4, 0]);
            List<ISymbol> symbolList41 = GenerateSpinSymbols(40, symbols[4, 1]);
            List<ISymbol> symbolList42 = GenerateSpinSymbols(40, symbols[4, 2]);

            for (int i = 0; i < 41; i++)
            {
                if (i < 20 + 1)
                {
                    this.Symbol00 = SymbolToPath(symbolList00[i]);
                    this.Symbol01 = SymbolToPath(symbolList01[i]);
                    this.Symbol02 = SymbolToPath(symbolList02[i]);
                }
                if (i < 25 + 1)
                {
                    this.Symbol10 = SymbolToPath(symbolList10[i]);
                    this.Symbol11 = SymbolToPath(symbolList11[i]);
                    this.Symbol12 = SymbolToPath(symbolList12[i]);
                }
                if (i < 30 + 1)
                {
                    this.Symbol20 = SymbolToPath(symbolList20[i]);
                    this.Symbol21 = SymbolToPath(symbolList21[i]);
                    this.Symbol22 = SymbolToPath(symbolList22[i]);
                }
                if (i < 35 + 1)
                {
                    this.Symbol30 = SymbolToPath(symbolList30[i]);
                    this.Symbol31 = SymbolToPath(symbolList31[i]);
                    this.Symbol32 = SymbolToPath(symbolList32[i]);
                }

                this.Symbol40 = SymbolToPath(symbolList40[i]);
                this.Symbol41 = SymbolToPath(symbolList41[i]);
                this.Symbol42 = SymbolToPath(symbolList42[i]);

                await Task.Delay(millisecondsDelay);
            }
        }

        private static List<ISymbol> GenerateSpinSymbols(int count, ISymbol endSymbol)
        {
            List<ISymbol> generate = GenerateSymbolList();
            List<ISymbol> list = new List<ISymbol>();

            Random random = new Random();
            int max = generate.Count - 1;
            int index = random.Next(max);

            for (int i = 0; i < count; i++)
            {
                list.Add(generate[index]);
                index = NextIndex(index, max);
            }

            list.Add(endSymbol);

            return list;
        }

        private static int NextIndex(int index, int max)
        {
            if (index == max)
            {
                return 0;
            }

            return index + 1;
        }

        private static List<ISymbol> GenerateSymbolList()
        {
            return new List<ISymbol>()
            {
                new TenSymbol(),
                new JSymbol(),
                new QSymbol(),
                new KSymbol(),
                new ASymbol(),
                new JoegiSymbol(),
                new VincSymbol(),
                new SimiSymbol()
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
