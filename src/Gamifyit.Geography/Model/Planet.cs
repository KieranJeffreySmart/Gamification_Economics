namespace Gamifyit.Geography.Model
{
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Geography.ModelState;

    public class Planet : Entity<ModelState.Planet>
    {
        private readonly EntityCollection<City, ModelState.City> cities;

        public Planet(ModelState.Planet state) : base(state)
        {
            this.cities = new EntityCollection<City, ModelState.City>(this.State.Cities, (s) => new City(s));
        }

        public IReadOnlyCollection<City> Cities => this.cities;
    }
}
