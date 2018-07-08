using SpaceTrader.Framework.DomainObjects;

namespace SpaceTrader.Model
{
    public class Address : Entity<ModelState.Address>
    {
        public Address(ModelState.Address state) : base(state)
        {
        }
    }
}
