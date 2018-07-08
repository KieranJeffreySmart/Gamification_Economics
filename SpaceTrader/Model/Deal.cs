using SpaceTrader.Framework.DomainObjects;

namespace SpaceTrader.Model
{
    public class Deal : Entity<ModelState.Deal>
    {
        public Deal(ModelState.Deal state) : base(state)
        {
        }
    }
}
