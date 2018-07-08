using SpaceTrader.Framework.DomainObjects;

namespace SpaceTrader.Model
{
    public class Service : Entity<ModelState.Service>
    {
        public Service(ModelState.Service state) : base(state)
        {
        }
    }
}
