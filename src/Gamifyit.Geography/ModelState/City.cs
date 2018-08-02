namespace Gamifyit.Geography.ModelState
{
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;

    public class City: EntityState
    {
        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public City CloneAsSelf()
        {
            var clone = (City)this.MemberwiseClone();
            return clone;
        }
    }
}
