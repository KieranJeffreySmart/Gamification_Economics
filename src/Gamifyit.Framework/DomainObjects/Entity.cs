namespace Gamifyit.Framework.DomainObjects
{
    public abstract class Entity<TModelState> : ICloneableEntity<TModelState> where TModelState : EntityState
    {
        protected Entity(TModelState state)
        {
            this.State = state;
            this.Identity = new EntityIdentity(this.State.Identity);
        }

        public TModelState State { get; }

        public EntityIdentity Identity { get; }

        public TModelState CloneState()
        {
            return this.State.Clone() as TModelState;
        }
    }
}
