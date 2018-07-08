namespace SpaceTrader.Framework.DomainObjects
{
    public abstract class Entity<TModelState>
    {
        internal TModelState State { get; }

        public Entity(TModelState state)
        {
            this.State = state;
        }

        public StateIdentity Identity { get; }
    }
}
