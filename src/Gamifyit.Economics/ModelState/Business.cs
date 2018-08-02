namespace Gamifyit.Economics.ModelState
{
    using System.Collections.Generic;
    using System.Linq;

    using Gamifyit.Framework.DomainObjects;

    public class Business : EntityState
    {
        public string Name { get; set; }
        public int Type { get; set; }

        public IList<Office> Offices { get; set; } = new List<Office>();
        public IList<Facility> Facilities { get; set; } = new List<Facility>();
        public IList<Service> Services { get; set; } = new List<Service>();
        public IList<Deal> OpenDeals { get; set; } = new List<Deal>();
        public IList<Deal> DealsMade { get; set; } = new List<Deal>();

        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public Business CloneAsSelf()
        {
            var clone = (Business)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();
            clone.Offices = this.Offices.Select(o => o.CloneAsSelf()).ToList();
            clone.Facilities = this.Facilities.Select(o => o.CloneAsSelf()).ToList();
            clone.Services = this.Services.Select(o => o.CloneAsSelf()).ToList();
            clone.OpenDeals = this.OpenDeals.Select(o => o.CloneAsSelf()).ToList();
            clone.DealsMade = this.DealsMade.Select(o => o.CloneAsSelf()).ToList();
            return clone;
        }
    }
}
