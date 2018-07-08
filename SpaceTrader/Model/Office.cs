using SpaceTrader.Framework.DomainObjects;

namespace SpaceTrader.Model
{
    public class Office : Entity<ModelState.Office>
    {
        public Office(ModelState.Office state) : base(state)
        {
        }
    }
}
