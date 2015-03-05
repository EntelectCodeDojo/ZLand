namespace ZLand.Items.Armor
{
    public abstract class Armor : Item
    {
        protected Armor(string name, string description, double baseValue, double weight, double durability, double damageReductionPercent) 
            : base(name, description, baseValue, weight, durability)
        {
            DamageReductionPercent = damageReductionPercent;
        }

        public double DamageReductionPercent { get; private set; }
    }
}