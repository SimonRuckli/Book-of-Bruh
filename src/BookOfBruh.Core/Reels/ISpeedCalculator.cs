namespace BookOfBruh.Core.Reels
{
    using System.Collections.Generic;
    using System.Linq;

    public interface ISpeedCalculator
    {
        List<int> Calculate(int times);
    }

    public class SpeedCalculator : ISpeedCalculator
    {
        private const int minSpeed = 400;
        private const int maxSpeed = 10;

        public List<int> Calculate(int times)
        {
            var speeds = new List<int>() { minSpeed };

            for (int i = 0; i < times; i++)
            {
                int speed = (int) (speeds.Last() / 1.4d);
                speeds.Add(speed < maxSpeed ? maxSpeed : speed);
            }

            speeds.Reverse();

            return speeds;
        }
    }
}