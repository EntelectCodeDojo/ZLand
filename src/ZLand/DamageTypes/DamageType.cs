namespace ZLand.DamageTypes
{
    public abstract class DamageType
    {
        public abstract string Name { get; }

        public static BluntForce BluntForce()
        {
            return new BluntForce();
        }
    }
}