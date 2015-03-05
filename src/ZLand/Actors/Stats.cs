using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ZLand.Actors
{
    public class Stats
    {
        public Stats()
        {
            Intelligence = 1;
            Wisdom = 1;
            Strength = 1;
            Dexterity = 1; 
            Constitution = 1;
            Agility = 1;
            Luck = 1;
            Charisma = 1;
        }

        public Stats(int intelligence, int wisdom, int dexterity, int strength, int constitution, int agility, int luck, int charisma)
        {
            var sum = intelligence + wisdom + dexterity + strength + constitution + agility + luck + charisma;
            if (sum > 8)
            {
                throw new ArgumentException("Sum of stats cannot be greater than 160");
            }
            Intelligence = intelligence;
            Wisdom = wisdom;
            Dexterity = dexterity;
            Strength = strength;
            Constitution = constitution;
            Agility = agility;
            Luck = luck;
            Charisma = charisma;
            Validate();
        }

        private void Validate()
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(this, new ValidationContext(this, null, null), results, true);
            if (results.Any())
            {
                var joinedErrorMessage = string.Join(",", results.Select(result => result.ErrorMessage));
                throw new ValidationException(joinedErrorMessage);
            }
        }

        [Range(1,20)]
        public int Intelligence { get; private set; }
        [Range(1, 20)]
        public int Wisdom { get; private set; }
        [Range(1, 20)]
        public int Strength { get; private set; }
        [Range(1, 20)]
        public int Dexterity { get; private set; }
        [Range(1, 20)]
        public int Constitution { get; private set; }
        [Range(1, 20)]
        public int Agility { get; private set; }
        [Range(1, 20)]
        public int Luck { get; private set; }
        [Range(1, 20)]
        public int Charisma { get; private set; }

        public LuckRoll MakeLuckRoll()
        {
            return (LuckRoll) new Random().Next(0, 2);
        }
    }
}