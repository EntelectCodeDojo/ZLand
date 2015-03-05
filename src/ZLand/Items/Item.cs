using System;
using ZLand.Actors;

namespace ZLand.Items
{
    public abstract class Item
    {
        protected Item(string name, string description, double baseValue, double weight, double durability)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name", "Name cannot be null");
            }
            Name = name;
            Description = description;
            if (baseValue < 0)
            {
                throw new ArgumentException("BaseValue cannot be less than 0");
            }
            BaseValue = baseValue;
            if (weight < 0)
            {
                throw new ArgumentException("Weight cannot be less than 0");
            }
            Weight = weight;
            if (durability < 0 || durability > 1)
            {
                throw new ArgumentException("Durability must be between 0 and 1");
            }
            Durability = durability;
        }
        /// <summary>
        /// Gets the name of the item.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Gets the description.
        /// </summary>
        public string Description { get; private set; }
        /// <summary>
        /// Gets the durability between 0 & 1 of the item, once it reaches 0 the item may need to be repaired.
        /// </summary>
        public double Durability { get; private set; }
        /// <summary>
        /// Gets the base value of the item to use when calculating sales.
        /// </summary>
        public double BaseValue { get; private set; }
        /// <summary>
        /// Gets the weight of the item in kg's.
        /// </summary>
        public double Weight { get; private set; }

        /// <summary>
        /// Gets the current value of the item, excluding luck and Charisma modifiers.
        /// </summary>
        public virtual double GetCurrentValue()
        {
            return BaseValue * Durability;
        }


        /// <summary>
        /// Gets the calculated sales value of the item as sold by the current actor, factoring in luck and charisma.
        /// </summary>
        /// <param name="actor">The actor making the sale.</param>
        public virtual double GetSalesValue(Actor actor)
        {
            var calculatedValue = GetCurrentValue();
            calculatedValue = ApplyCharismaRatingToValue(calculatedValue, actor.Stats.Charisma);
            var luckRoll = actor.Stats.MakeLuckRoll();
            if (luckRoll == LuckRoll.Bad)
            {
                calculatedValue = calculatedValue*0.95;
            }
            else if (luckRoll == LuckRoll.Good)
            {
                calculatedValue = calculatedValue * 1.05;
            }
            return calculatedValue;
        }

        /// <summary>
        /// Uses the supplied charisma value (On a sliding scale) to modify the sales price of the item
        /// </summary>
        /// <param name="currentValue">The current value of the item.</param>
        /// <param name="charisma">The actors charisma.</param>
        protected internal virtual double ApplyCharismaRatingToValue(double currentValue, int charisma)
        {
            if (charisma == 7)
            {
                return currentValue*2;
            }
            var charismaModifier = (double)charisma/100;
            var priceModifier = charismaModifier + 0.9;
            return currentValue * priceModifier;
        }
    }
}