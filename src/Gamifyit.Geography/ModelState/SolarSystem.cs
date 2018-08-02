namespace Gamifyit.Geography.ModelState
{
    using System.Collections.Generic;
    using System.Linq;

    using Gamifyit.Framework.DomainObjects;

    public class SolarSystem : EntityState
    {
        public IList<Planet> Planets { get; set; } = new List<Planet>();

        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public SolarSystem CloneAsSelf()
        {
            var clone = (SolarSystem)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();
            clone.Planets = this.Planets.Select(o => o.CloneAsSelf()).ToList();
            return clone;
        }
    }
}
