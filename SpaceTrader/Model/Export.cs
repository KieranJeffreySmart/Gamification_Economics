using SpaceTrader.Framework.DomainObjects;

namespace SpaceTrader.Model
{
    public class Export : Entity<ModelState.Export>
    {
        public Export(ModelState.Export state) : base(state)
        {
        }
    }
}
