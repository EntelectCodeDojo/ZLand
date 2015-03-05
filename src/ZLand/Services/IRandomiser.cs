namespace ZLand.Services
{
    public interface IRandomiser
    {
        int RandomInt(int min, int max);
        int[] RandomIntArray(int minValuePerItem, int maxValuePerItem, int itemValueSum);
        /// <summary>
        /// Returns a random number between 0.0 and 1.0.
        /// </summary>
        /// <returns>
        /// A double-precision floating point number greater than or equal to 0.0, and less than 1.0.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        double Double();
    }
}