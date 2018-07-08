using SpaceTrader.Framework;
using SpaceTrader.Framework.DomainObjects;
using SpaceTrader.ModelState;
using System.Collections.Generic;

namespace SpaceTrader.Model
{
    public class SolarSystem : Entity<ModelState.SolarSystem>
    {
        private readonly EntityCollection<Planet, ModelState.Planet> planets;

        public SolarSystem(ModelState.SolarSystem state) : base(state)
        {
            planets = new EntityCollection<Planet, ModelState.Planet>(this.State.Planets, (s) => new Planet(s));
        }

        public IReadOnlyCollection<Planet> Planets => planets;
    }
}
