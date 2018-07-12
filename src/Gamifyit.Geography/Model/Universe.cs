namespace Gamifyit.Geography.Model
{
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;

    public class Universe: Entity<ModelState.Universe>
    {
        private readonly EntityCollection<Galaxy, ModelState.Galaxy> galaxies;
        public IReadOnlyCollection<Galaxy> Galaxies => this.galaxies;

        public Universe(ModelState.Universe state): base(state)
        {
            this.galaxies = new EntityCollection<Galaxy, ModelState.Galaxy>(this.State.Galaxies, (s) => new Galaxy(s));
        }
    }
}
