namespace Gamifyit.Geography.ModelState
{
    using System.Collections.Generic;
    using System.Linq;

    using Gamifyit.Framework.DomainObjects;

    public class Universe : EntityState
    {
        public IList<Galaxy> Galaxies { get; set; } = new List<Galaxy>();

        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public Universe CloneAsSelf()
        {
            var clone = (Universe)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();
            clone.Galaxies = this.Galaxies.Select(o => o.CloneAsSelf()).ToList();
            return clone;
        }
    }
}
