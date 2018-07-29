namespace Gamifyit.Framework.DomainObjects
{
    using System;

    public abstract class Entity<TModelState> where TModelState : EntityState
    {
        public TModelState State { get; }

        public Entity(TModelState state)
        {
            this.State = state;
            this.Identity = this.State.Identity != null ? new EntityIdentity(this.State.Identity.Index, this.State.Identity.Reference) : new EntityIdentity(0, Guid.NewGuid().ToString());
        }

        public EntityIdentity Identity { get; set; }
    }
}
