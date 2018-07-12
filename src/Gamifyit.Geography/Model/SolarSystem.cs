namespace Gamifyit.Geography.Model
{
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;

    public class SolarSystem : Entity<ModelState.SolarSystem>
    {
        private readonly EntityCollection<Planet, ModelState.Planet> planets;

        public SolarSystem(ModelState.SolarSystem state) : base(state)
        {
            this.planets = new EntityCollection<Planet, ModelState.Planet>(this.State.Planets, (s) => new Planet(s));
        }

        public IReadOnlyCollection<Planet> Planets => this.planets;
    }
}
