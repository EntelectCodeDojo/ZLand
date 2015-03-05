namespace ZLand.Actors
{
    public abstract class Zombie : Actor
    {
        public double ResurectPercentChance { get; set; }
        public Health ResurectionHealth { get; set; }
    }
}