using ZLand.Services;

namespace ZLand.Tests.Actions
{
    public class BasicRandomiser : IRandomiser
    {
        public int RandomInt(int min, int max)
        {
            return 1;
        }

        public int[] RandomIntArray(int minValuePerItem, int maxValuePerItem, int itemValueSum)
        {
            return new[] {1,1,1,1,1,1,1,1};
        }

        public double Double()
        {
            return 1.0;
        }
    }
}