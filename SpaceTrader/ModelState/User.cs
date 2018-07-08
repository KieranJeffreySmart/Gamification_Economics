using SpaceTrader.Framework.DomainObjects;

namespace SpaceTrader.ModelState
{
    public class User : EntityState
    {
        public Membership Membership { get; set; }
    }
}
