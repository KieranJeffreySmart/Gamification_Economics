namespace Gamifyit.Economics.ModelState
{
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;

    public class Business : EntityState
    {
        public string Name { get; set; }
        public int Type { get; }

        public IList<Office> Offices { get; set; } = new List<Office>();
        public IList<Facility> Facilities { get; set; } = new List<Facility>();
        public IList<Service> Services { get; set; } = new List<Service>();
        public IList<Deal> OpenDeals { get; set; } = new List<Deal>();
        public IList<Deal> DealsMade { get; set; } = new List<Deal>();
    }

    public class BusinessListingBoard : EntityState
    {
        public IList<StateIdentity> Businesses { get; set; } = new List<StateIdentity>();
    }
}
