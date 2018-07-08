using SpaceTrader.Framework.DomainObjects;

namespace SpaceTrader.Model
{
    public class Import : Entity<ModelState.Import>
    {
        public Import(ModelState.Import state) : base(state)
        {
        }
    }
}
