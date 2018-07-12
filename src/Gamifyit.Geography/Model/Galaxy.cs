namespace Gamifyit.Geography.Model
{
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;

    public class Galaxy : Entity<ModelState.Galaxy>
    {
        private readonly EntityCollection<SolarSystem, ModelState.SolarSystem> solarSystems;

        public Galaxy(ModelState.Galaxy state) : base(state)
        {
            this.solarSystems = new EntityCollection<SolarSystem, ModelState.SolarSystem>(this.State.SolarSystems, (s) => new SolarSystem(s));
        }

        public IReadOnlyCollection<SolarSystem> SolarSystems => this.solarSystems;
    }
}
