using ZLand.Actors;

namespace ZLand.Actions
{
    public abstract class SameCellAction : Action
    {
        protected SameCellAction(int cost, string name)
            : base(cost, name)
        {
        }
        
        public abstract void Apply(Actor initiatingActor);
    }
}