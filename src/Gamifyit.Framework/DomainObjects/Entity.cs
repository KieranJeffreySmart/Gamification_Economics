namespace Gamifyit.Framework.DomainObjects
{
    using System;

    public abstract class Entity<TModelState> : ICloneableEntity<TModelState> where TModelState : EntityState
    {
        public TModelState State { get; }

        public Entity(TModelState state)
        {
            this.State = state;
            this.Identity = new EntityIdentity(this.State.Identity);
        }

        public EntityIdentity Identity { get; set; }

        public TModelState CloneState()
        {
            return this.State.Clone() as TModelState;
        }

        internal void SetIdentity(StateIdentity identity)
        {
            this.State.Identity = identity;
        }
    }
}
