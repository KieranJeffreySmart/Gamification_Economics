using SpaceTrader.Framework;
using SpaceTrader.Framework.DomainObjects;
using System.Collections.Generic;

namespace SpaceTrader.Model
{

    public class Universe: Entity<ModelState.Universe>
    {
        private readonly EntityCollection<Galaxy, ModelState.Galaxy> galaxies;
        public IReadOnlyCollection<Galaxy> Galaxies => galaxies;

        public Universe(ModelState.Universe state): base(state)
        {
            galaxies = new EntityCollection<Galaxy, ModelState.Galaxy>(this.State.Galaxies, (s) => new Galaxy(s));
        }
    }
}
