using SpaceTrader.Framework;
using SpaceTrader.Framework.DomainObjects;
using System.Collections.Generic;

namespace SpaceTrader.Model
{
    public class City : Entity<ModelState.City>
    {
        public City(ModelState.City state) : base(state)
        {
            resources = new EntityCollection<Resource, ModelState.Resource>(this.State.Resources, (s) => new Resource(s));
        }

        private readonly EntityCollection<Resource, ModelState.Resource> resources;
        public IReadOnlyCollection<Resource> Resources => resources;
    }
}
