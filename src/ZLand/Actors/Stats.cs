using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ZLand.Services;

namespace ZLand.Actors
{
    public class Stats : IValidatableObject
    {
        public INotificiationService NotificiationService { get; private set; }
        public IRandomiser Randomiser { get; private set; }

        public Stats(INotificiationService notificiationService, IRandomiser randomiser)
        {
            NotificiationService = notificiationService;
            Randomiser = randomiser;
            notificiationService.Notify("Generating stats for actor");
            var statsPool = Randomiser.RandomInt(100, 160);
            notificiationService.Notify(string.Format("StatsPool: {0}", statsPool));
            var randomStats = randomiser.RandomIntArray(1, 20, statsPool, 8);
            Intelligence = randomStats[0];
            notificiationService.Notify(string.Format("Intelligence: {0}", Intelligence));
            Wisdom = randomStats[1];
            notificiationService.Notify(string.Format("Wisdom: {0}", Wisdom));
            Strength = randomStats[2];
            notificiationService.Notify(string.Format("Strength: {0}", Strength));
            Dexterity = randomStats[3];
            notificiationService.Notify(string.Format("Dexterity: {0}", Dexterity));
            Constitution = randomStats[4];
            notificiationService.Notify(string.Format("Constitution: {0}", Constitution));
            Agility = randomStats[5];
            notificiationService.Notify(string.Format("Agility: {0}", Agility));
            Luck = randomStats[6];
            notificiationService.Notify(string.Format("Luck: {0}", Luck));
            Charisma = randomStats[7];
            notificiationService.Notify(string.Format("Charisma: {0}", Charisma));
            ValidateAndThrowExceptionIfErrors();
        }


        public Stats(int intelligence, int wisdom, int dexterity, int strength, int constitution, int agility, int luck, int charisma, INotificiationService notificiationService, IRandomiser randomiser)
        {
            Intelligence = intelligence;
            Wisdom = wisdom;
            Dexterity = dexterity;
            Strength = strength;
            Constitution = constitution;
            Agility = agility;
            Luck = luck;
            Charisma = charisma;
            NotificiationService = notificiationService;
            Randomiser = randomiser;
            ValidateAndThrowExceptionIfErrors();
        }

        public void ValidateAndThrowExceptionIfErrors()
        {
            var context = new ValidationContext(this, null, null);
            var results = Validate(context).ToList();
            if (results.Any())
            {
                var joinedErrorMessage = string.Join(",", results.Select(result => result.ErrorMessage));
                throw new ValidationException(joinedErrorMessage);
            }
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(this, validationContext, results, true);
            results.AddRange(DoCustomValidation());
            return results;
        }

        private IEnumerable<ValidationResult> DoCustomValidation()
        {
            var results = new List<ValidationResult>();
            var sum = Intelligence + Wisdom + Dexterity + Strength + Constitution + Agility + Luck + Charisma;
            if (sum > 1)
            {
                results.Add(new ValidationResult("Sum of stats cannot be greater than 160"));
            }
            return results;
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
            var luckRoll = (LuckRoll) Randomiser.RandomInt(0, 2);
            NotificiationService.Notify(string.Format("LuckRoll value : {0}", luckRoll));
            return luckRoll;
        }
    }
}