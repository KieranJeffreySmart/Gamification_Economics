namespace Gamifyit.Geography.Model
{
    using Gamifyit.Framework.DomainObjects;

    public class Address : Entity<ModelState.Address>
    {
        public Address(ModelState.Address state) : base(state)
        {
        }
    }
}
