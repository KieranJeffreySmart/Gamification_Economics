using SpaceTrader.Framework.DomainObjects;

namespace SpaceTrader.Model
{
    public class Company : Entity<ModelState.Company>
    {
        public Company(ModelState.Company state) : base(state)
        {
        }

        Business Business { get; set; }
    }
}
