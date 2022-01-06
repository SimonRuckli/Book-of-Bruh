namespace BookOfBruh.Core.Test.Slot
{
    using System.Collections.Generic;
    using SlotGeneration;
    using Symbols;
    using FluentAssertions;
    using Xunit;
    using System.Linq;

    public class SymbolGeneratorTest
    {
        [Fact]
        public void SymbolGeneratorShouldReturnEighteenTenSymbolWhenHundredSymbolsGenerated()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator(new FakeSymbolListGenerator());
            const int n = 100;
            const int expected = 18;

            var symbols = new ISymbol[n];

            // Act
            for (var i = 0; i < n; i++)
            {
                symbols[i] = testee.Generate(i);
            }

            // Assert
            symbols.Count(s => s is TenSymbol).Should().Be(expected);
            
        }

        [Fact]
        public void SymbolGeneratorShouldReturnEighteenJSymbolWhenHundredSymbolsGenerated()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator(new FakeSymbolListGenerator());
            const int n = 100;
            const int expected = 18;

            var symbols = new ISymbol[n];

            // Act
            for (var i = 0; i < n; i++)
            {
                symbols[i] = testee.Generate(i);
            }

            // Assert
            symbols.Count(s => s is JSymbol).Should().Be(expected);

        }

        [Fact]
        public void SymbolGeneratorShouldReturnFourteenQSymbolWhenHundredSymbolsGenerated()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator(new FakeSymbolListGenerator());
            const int n = 100;
            const int expected = 14;

            var symbols = new ISymbol[n];

            // Act
            for (var i = 0; i < n; i++)
            {
                symbols[i] = testee.Generate(i);
            }

            // Assert
            symbols.Count(s => s is QSymbol).Should().Be(expected);

        }

        [Fact]
        public void SymbolGeneratorShouldReturnFourteenKSymbolWhenHundredSymbolsGenerated()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator(new FakeSymbolListGenerator());
            const int n = 100;
            const int expected = 14;

            var symbols = new ISymbol[n];

            // Act
            for (var i = 0; i < n; i++)
            {
                symbols[i] = testee.Generate(i);
            }

            // Assert
            symbols.Count(s => s is KSymbol).Should().Be(expected);

        }

        [Fact]
        public void SymbolGeneratorShouldReturnTenASymbolWhenHundredSymbolsGenerated()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator(new FakeSymbolListGenerator());
            const int n = 100;
            const int expected = 10;

            var symbols = new ISymbol[n];

            // Act
            for (var i = 0; i < n; i++)
            {
                symbols[i] = testee.Generate(i);
            }

            // Assert
            symbols.Count(s => s is ASymbol).Should().Be(expected);

        }

        [Fact]
        public void SymbolGeneratorShouldReturnEightJoegiSymbolWhenHundredSymbolsGenerated()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator(new FakeSymbolListGenerator());
            const int n = 100;
            const int expected = 8;

            var symbols = new ISymbol[n];

            // Act
            for (var i = 0; i < n; i++)
            {
                symbols[i] = testee.Generate(i);
            }

            // Assert
            symbols.Count(s => s is JoegiSymbol).Should().Be(expected);

        }

        [Fact]
        public void SymbolGeneratorShouldReturnSevenVincSymbolWhenHundredSymbolsGenerated()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator(new FakeSymbolListGenerator());
            const int n = 100;
            const int expected = 7;

            var symbols = new ISymbol[n];

            // Act
            for (var i = 0; i < n; i++)
            {
                symbols[i] = testee.Generate(i);
            }

            // Assert
            symbols.Count(s => s is VincSymbol).Should().Be(expected);

        }

        [Fact]
        public void SymbolGeneratorShouldReturnSixSimiSymbolWhenHundredSymbolsGenerated()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator(new FakeSymbolListGenerator());
            const int n = 100;
            const int expected = 6;

            var symbols = new ISymbol[n];

            // Act
            for (var i = 0; i < n; i++)
            {
                symbols[i] = testee.Generate(i);
            }

            // Assert
            symbols.Count(s => s is SimiSymbol).Should().Be(expected);

        }

        [Fact]
        public void SymbolGeneratorShouldReturnFiveWildSymbolWhenHundredSymbolsGenerated()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator(new FakeSymbolListGenerator());
            const int n = 100;
            const int expected = 5;

            var symbols = new ISymbol[n];

            // Act
            for (var i = 0; i < n; i++)
            {
                symbols[i] = testee.Generate(i);
            }

            // Assert
            symbols.Count(s => s is WildSymbol).Should().Be(expected);

        }
    }

    public class FakeSymbolListGenerator : ISymbolListGenerator
    {
        public List<ISymbol> Generate()
        {
            var symbols = new List<ISymbol>();

            for (var i = 0; i < 18; i++)
            {
                symbols.Add(new JSymbol());
                symbols.Add(new TenSymbol());
            }

            for (var i = 0; i < 14; i++)
            {
                symbols.Add(new QSymbol());
                symbols.Add(new KSymbol());
            }

            for (var i = 0; i < 10; i++)
            {
                symbols.Add(new ASymbol());
            }

            for (var i = 0; i < 8; i++)
            {
                symbols.Add(new JoegiSymbol());
            }

            for (var i = 0; i < 7; i++)
            {
                symbols.Add(new VincSymbol());
            }

            for (var i = 0; i < 6; i++)
            {
                symbols.Add(new SimiSymbol());
            }

            for (var i = 0; i < 5; i++)
            {
                symbols.Add(new WildSymbol());
            }

            return symbols;
        }
    }
}