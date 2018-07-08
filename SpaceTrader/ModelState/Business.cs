using System.Collections.Generic;
using SpaceTrader.Framework.DomainObjects;

namespace SpaceTrader.ModelState
{
    public class Business : EntityState
    {
        public string Name { get; set; }
        public BusinessType Type { get; }

        public IList<Office> Offices { get; set; } = new List<Office>();
        public IList<Facility> Facilities { get; set; } = new List<Facility>();
        public IList<Service> Services { get; set; } = new List<Service>();
        public IList<Deal> OpenDeals { get; set; } = new List<Deal>();
        public IList<Deal> DealsMade { get; set; } = new List<Deal>();
    }

    public class BusinessType
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class BusinessListingBoard
    {
        public IList<StateIdentity> Businesses { get; set; } = new List<StateIdentity>();
    }
}
