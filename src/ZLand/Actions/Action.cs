namespace ZLand.Actions
{
    public abstract class Action
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Cost { get; private set; }

        protected Action(int baseCost, string name)
        {
            Cost = baseCost;
            Name = name;
            Description = string.Empty;
        }
    }
}