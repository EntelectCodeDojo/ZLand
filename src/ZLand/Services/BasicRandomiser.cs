using System;

namespace ZLand.Services
{
    public class BasicRandomiser : IRandomiser
    {
        public int RandomInt(int min, int max)
        {
            var randomiser = new Random();
            return randomiser.Next(min,max);
        }

        public int[] RandomIntArray(int minValuePerItem, int maxValuePerItem, int itemValueSum, int arraySize)
        {
            var stats = new int[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                var value = RandomInt(minValuePerItem, maxValuePerItem);
                stats[0] = value;
            }
            return stats;
        }

        public double Double()
        {
            var randomiser = new Random();
            return randomiser.NextDouble();
        }
    }
}