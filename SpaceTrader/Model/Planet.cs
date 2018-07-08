using SpaceTrader.Framework;
using SpaceTrader.Framework.DomainObjects;
using SpaceTrader.ModelState;
using System.Collections.Generic;

namespace SpaceTrader.Model
{
    public class Planet : Entity<ModelState.Planet>
    {
        private readonly EntityCollection<City, ModelState.City> cities;

        public Planet(ModelState.Planet state) : base(state)
        {
            cities = new EntityCollection<City, ModelState.City>(this.State.Cities, (s) => new City(s));
        }

        public IReadOnlyCollection<City> Cities => cities;
    }
}
