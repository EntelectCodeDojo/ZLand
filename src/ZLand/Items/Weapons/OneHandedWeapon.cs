using System.Collections.Generic;
using ZLand.Actions;

namespace ZLand.Items.Weapons
{
    public abstract class OneHandedWeapon: Weapon
    {
        protected OneHandedWeapon(string name, string description, double baseValue, double weight, double durability, List<Action> actions, bool isTwoHanded) 
            : base(name, description, baseValue, weight, durability, actions, isTwoHanded)
        {
        }
    }
}