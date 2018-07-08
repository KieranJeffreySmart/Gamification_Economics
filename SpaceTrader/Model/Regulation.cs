using SpaceTrader.Framework.DomainObjects;

namespace SpaceTrader.Model
{
    public class Regulation : Entity<ModelState.Regulation>
    {
        public Regulation(ModelState.Regulation state) : base(state)
        {
        }
    }
}
