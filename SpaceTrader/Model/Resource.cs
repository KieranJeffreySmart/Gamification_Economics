using SpaceTrader.Framework.DomainObjects;

namespace SpaceTrader.Model
{
    public class Resource : Entity<ModelState.Resource>
    {
        public Resource(ModelState.Resource state) : base(state)
        {
        }
    }
}
