using SpaceTrader.Framework;
using SpaceTrader.Framework.DomainObjects;
using SpaceTrader.ModelState;
using System.Collections.Generic;

namespace SpaceTrader.Model
{
    public class Galaxy : Entity<ModelState.Galaxy>
    {
        private readonly EntityCollection<SolarSystem, ModelState.SolarSystem> solarSystems;

        public Galaxy(ModelState.Galaxy state) : base(state)
        {
            solarSystems = new EntityCollection<SolarSystem, ModelState.SolarSystem>(this.State.SolarSystems, (s) => new SolarSystem(s));
        }

        public IReadOnlyCollection<SolarSystem> SolarSystems => solarSystems;
    }
}
