using System.Collections.Generic;
using ZLand.Actions;

namespace ZLand.Items
{
    public abstract class ActionableItem : Item
    {
        protected ActionableItem(string name, string description, double baseValue, double weight, double durability, List<Action> actions) 
            : base(name, description, baseValue, weight, durability)
        {
            Actions = actions;
        }

        public List<Action> Actions { get; set; }
    }
}