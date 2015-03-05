using System;
using System.Collections.Generic;
using ZLand.Actions;
using ZLand.Items;
using ZLand.Items.Armor;
using ZLand.Items.Weapons;
using ZLand.World;
using Action = ZLand.Actions.Action;

namespace ZLand.Actors
{
    /// <summary>
    /// Represents an entity in the game that can perform actions
    /// </summary>
    public abstract class Actor
    {
        protected Actor(int actionPointsPerTurn, Cell currentPosition, int baseMoveSpeed, Stats stats, int maxHealth, double maximumWeight)
        {
            if (actionPointsPerTurn < 1)
            {
                throw new ArgumentException("ActionPointsPerTurn cannot be less than 1");
            }
            ActionPointsPerTurn = actionPointsPerTurn;
            CurrentActionPoints = actionPointsPerTurn;
            if (currentPosition == null)
            {
                throw new ArgumentNullException("currentPosition", "CurrentPosition cannot be null");
            }
            CurrentPosition = currentPosition;
            if (baseMoveSpeed < 0)
            {
                throw new ArgumentException("BaseMoveSpeed cannot be less than 0");
            }
            BaseMoveSpeed = baseMoveSpeed;
            if (stats == null)
            {
                throw new ArgumentNullException("stats","Stats cannot be null");
            }
            Stats = stats;
            if (maxHealth < 1)
            {
                throw new ArgumentException("MaxHealth cannot be less than 1");
            }
            MaxHealth = maxHealth;
            CurrentHealth = MaxHealth;
            if (maximumWeight < 0)
            {
                throw new ArgumentException("MaximumWeight cannot be less than 0");
            }
            MaximumWeight = maximumWeight;
            EncumberedWeight = MaximumWeight*0.75;
            IsAlive = true;
            Actions = new List<Action>();
            Inventory = new List<Item>();
        }

        /// <summary>
        /// How many cells the actor can move per action point
        /// </summary>
        public int BaseMoveSpeed { get; private set; }

        /// <summary>
        /// Gets the starting action points per turn.
        /// </summary>
        public int ActionPointsPerTurn { get; private set; }

        /// <summary>
        /// Gets the number of action points that can be spent this turn.
        /// </summary>
        public int CurrentActionPoints { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this actor is alive.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this actor is alive; otherwise, <c>false</c>.
        /// </value>
        public bool IsAlive { get; private set; }

        /// <summary>
        /// Gets the current health, when this reaches 0, the actor dies.
        /// </summary>
        public double CurrentHealth { get; private set; }

        /// <summary>
        /// Gets the maximum health for this actor, <see cref="CurrentHealth"/> cannot exceed this.
        /// </summary>
        public double MaxHealth { get; private set; }

        /// <summary>
        /// Gets the current position.
        /// </summary>
        public Cell CurrentPosition { get; private set; }

        /// <summary>
        /// Gets the currently equipped weapon.
        /// </summary>
        public Weapon EquippedWeapon { get; private set ; }

        /// <summary>
        /// Equips the supplied weapon.
        /// </summary>
        /// <param name="weapon">The weapon to equip.</param>
        public void EquipWeapon(Weapon weapon)
        {
            EquippedWeapon = weapon;
            throw new NotImplementedException("Does this cost action points?");
        }
        
        /// <summary>
        /// Gets the currently equipped armor.
        /// </summary>
        public Armor CurrentArmor { get; private set; }

        /// <summary>
        /// Equips the supplied armor.
        /// </summary>
        /// <param name="armor">The armor to equip.</param>
        public void EquipArmor(Armor armor)
        {
            CurrentArmor = armor;
            throw new NotImplementedException("Does this cost action points?");
        }

        /// <summary>
        /// Gets the stats for this actor.
        /// </summary>
        public Stats Stats { get; private set; }

        /// <summary>
        /// Gets the available actions the actor can perform.
        /// </summary>
        public List<Action> Actions { get; private set; }

        /// <summary>
        /// Gets the actor's inventory.
        /// </summary>
        public List<Item> Inventory { get; private set; }

        /// <summary>
        /// Gets the maximum weight that the actor can carry, if this is exceeded movement cannot occur.
        /// </summary>
        public double MaximumWeight { get; private set; }

        /// <summary>
        /// Gets the weight at which the actor becomes encumbered ( movement speed slowed by 50%).
        /// </summary>
        public double EncumberedWeight { get; private set; }

        protected void EnsureHasEnoughPoints(Action action)
        {
            if (CurrentActionPoints < action.Cost)
            {
                throw new NotEnoughActionPointsException();
            }
        }

        protected virtual void EnsureInRange(OtherCellAction action, Cell targetCell)
        {
            if (!IsInRange(action, targetCell))
            {
                throw new NotInRangeException();
            }
        }

        public virtual bool IsInRange(OtherCellAction action, Cell targetCell)
        {
            var distance = CurrentPosition.DistanceTo(targetCell);
            return distance <= action.Range;
        }

        protected void SpendPoints(Action action)
        {
            EnsureHasEnoughPoints(action);
            CurrentActionPoints -= action.Cost;
        }


        public virtual void PerformAction(SameCellAction action)
        {
            SpendPoints(action);
            action.Apply(this);
        }

        public virtual void PerformAction(OtherCellAction action, Cell targetCell)
        {
            EnsureInRange(action, targetCell);
            SpendPoints(action);
            action.Apply(this, targetCell);
        }

        public virtual void ApplyDamageFromAttack(AttackResult attackResult)
        {
            throw new System.NotImplementedException();
        }
    }
}