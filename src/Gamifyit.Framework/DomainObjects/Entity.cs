namespace Gamifyit.Framework.DomainObjects
{
    public abstract class Entity<TModelState>
    {
        public TModelState State { get; }

        public Entity(TModelState state)
        {
            this.State = state;
        }

        public StateIdentity Identity { get; }
    }
}
