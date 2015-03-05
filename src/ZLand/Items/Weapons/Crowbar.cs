using System.Collections.Generic;
using ZLand.Actions;
using ZLand.DamageTypes;

namespace ZLand.Items.Weapons
{
    public class Crowbar : OneHandedWeapon
    {
        public Crowbar()
            : base(name: "Crowbar",
                description: "Ask Gordon Freeman",
                baseValue: 40,
                weight: 2,
                durability: 1,
                actions: new List<Action>
                {
                    new MeleAttack(1, "Swing", 1, 3, DamageType.BluntForce(), 0.05, 0.05),
                    new MeleAttack(2, "Powerful Swing", 2, 8, DamageType.BluntForce(), 0.07, 0.09)
                },
                isTwoHanded: true)
        {
        }
    }
}