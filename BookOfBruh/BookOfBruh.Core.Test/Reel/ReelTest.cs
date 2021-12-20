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

            IReel testee = new Reel(symbols);
            const int times = 2;

            // Act
            await testee.Spin(times);

            // Assert
            using (new AssertionScope())
            {
                testee.First.Should().BeOfType(typeof(ASymbol));
                testee.Second.Should().BeOfType(typeof(ASymbol));
                testee.Third.Should().BeOfType(typeof(ASymbol));
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

            IReel testee = new Reel(symbols);
            const int times = 7;

            // Act
            await testee.Spin(times);

            // Assert
            using (new AssertionScope())
            {
                testee.First.Should().BeOfType(typeof(ASymbol));
                testee.Second.Should().BeOfType(typeof(QSymbol));
                testee.Third.Should().BeOfType(typeof(SimiSymbol));
            }
        }
        
    }
}
