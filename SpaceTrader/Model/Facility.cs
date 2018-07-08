using SpaceTrader.Framework.DomainObjects;

namespace SpaceTrader.Model
{
    public class Facility : Entity<ModelState.Facility>
    {
        public Facility(ModelState.Facility state) : base(state)
        {
        }
    }
}
