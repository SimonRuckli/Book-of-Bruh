namespace BookOfBruh.Core.Test.Reel
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FluentAssertions;
    using FluentAssertions.Execution;
    using Reels;
    using Symbols;
    using Xunit;

    public class ReelTest
    {
        [Fact]
        public async Task SpinTwoTimesShouldDisplayCorrectSymbol()
        {
            // Arrange
            List<ISymbol> symbols = new List<ISymbol>()
            {
                new ASymbol(),
                new ASymbol(),
                new ASymbol(),
                new ASymbol(),
                new ASymbol(),
            };

            ISpeedCalculator speedCalculator = new FakeSpeedCalculator();

            IReel testee = new Reel(symbols, speedCalculator);
            const int times = 2;

            // Act
            await testee.Spin(times);

            // Assert
            using (new AssertionScope())
            {
                testee.First.Symbol.Should().BeOfType(typeof(ASymbol));
                testee.Second.Symbol.Should().BeOfType(typeof(ASymbol));
                testee.Third.Symbol.Should().BeOfType(typeof(ASymbol));
            }
        }

        [Fact]
        public async Task SpinFullCircleShouldDisplayCorrectSymbol()
        {
            // Arrange
            List<ISymbol> symbols = new List<ISymbol>()
            {
                new TenSymbol(),
                new JSymbol(),
                new ASymbol(),
                new QSymbol(),
                new SimiSymbol(),
            };

            ISpeedCalculator speedCalculator = new FakeSpeedCalculator();

            IReel testee = new Reel(symbols, speedCalculator);
            const int times = 7;

            // Act
            await testee.Spin(times);

            // Assert
            using (new AssertionScope())
            {
                testee.First.Symbol.Should().BeOfType(typeof(SimiSymbol));
                testee.Second.Symbol.Should().BeOfType(typeof(QSymbol));
                testee.Third.Symbol.Should().BeOfType(typeof(ASymbol));
            }
        }
        
    }

    public class FakeSpeedCalculator : ISpeedCalculator
    {
        public List<int> Calculate(int times)
        {
            List<int> speeds = new List<int>();

            for (int i = 0; i < times; i++)
            {
                speeds.Add(1);
            }

            return speeds;
        }
    }
}
