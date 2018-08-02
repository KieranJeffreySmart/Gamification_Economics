namespace Gamifyit.Geography.ModelState
{
    using System.Collections.Generic;
    using System.Linq;

    using Gamifyit.Framework.DomainObjects;

    public class Planet : EntityState
    {
        public IList<City> Cities { get; set; } = new List<City>();

        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public Planet CloneAsSelf()
        {
            var clone = (Planet)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();
            clone.Cities = this.Cities.Select(o => o.CloneAsSelf()).ToList();
            return clone;
        }
    }
}
