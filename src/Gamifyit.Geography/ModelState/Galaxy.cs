namespace Gamifyit.Geography.ModelState
{
    using System.Collections.Generic;
    using System.Linq;

    using Gamifyit.Framework.DomainObjects;

    public class Galaxy : EntityState
    {
        public IList<SolarSystem> SolarSystems { get; set; } = new List<SolarSystem>();

        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public Galaxy CloneAsSelf()
        {
            var clone = (Galaxy)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();
            clone.SolarSystems = this.SolarSystems.Select(o => o.CloneAsSelf()).ToList();
            return clone;
        }
    }
}
