namespace Gamifyit.Economics.ModelState
{
    using System.Collections.Generic;
    using System.Linq;

    using Gamifyit.Framework.DomainObjects;

    public class BusinessListingBoard : EntityState
    {
        public IList<StateIdentity> Businesses { get; set; } = new List<StateIdentity>();

        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public BusinessListingBoard CloneAsSelf()
        {
            var clone = (BusinessListingBoard)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();

            clone.Businesses = this.Businesses.Select(o => o.CloneAsSelf()).ToList();
            return clone;
        }
    }
}