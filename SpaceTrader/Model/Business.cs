using SpaceTrader.Framework;
using SpaceTrader.Framework.DomainObjects;
using SpaceTrader.ModelState;
using SpaceTrader.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceTrader.Model
{
    public class Business : Entity<ModelState.Business>
    {
        public Business(ModelState.Business state) : base(state)
        {
            offices = new EntityCollection<Office, ModelState.Office>(this.State.Offices, (s) => new Office(s));
            facilities = new EntityCollection<Facility, ModelState.Facility>(this.State.Facilities, (s) => new Facility(s));
            services = new EntityCollection<Service, ModelState.Service>(this.State.Services, (s) => new Service(s));
            openDeals = new EntityCollection<Deal, ModelState.Deal>(this.State.OpenDeals, (s) => new Deal(s));
            dealsMade = new EntityCollection<Deal, ModelState.Deal>(this.State.DealsMade, (s) => new Deal(s));
        }

        public Business(string name) : base(new ModelState.Business
            {
                Name = name
            })
        {
        }

        private readonly EntityCollection<Office, ModelState.Office>  offices;
        private readonly EntityCollection<Facility, ModelState.Facility> facilities;
        private readonly EntityCollection<Service, ModelState.Service> services;
        private readonly EntityCollection<Deal, ModelState.Deal> openDeals;
        private readonly EntityCollection<Deal, ModelState.Deal> dealsMade;

        public string Name => this.State.Name;
        public IReadOnlyCollection<Office> Offices => offices;
        public IReadOnlyCollection<Facility> Facilities => facilities;
        public IReadOnlyCollection<Service> Services => services;
        public IReadOnlyCollection<Deal> OpenDeals => openDeals;
        public IReadOnlyCollection<Deal> DealsMade => dealsMade;
    }

    public class BusinessListingBoard : Entity<ModelState.BusinessListingBoard>
    {
        private readonly IBusinessRepository businessRepo;

        public BusinessListingBoard(ModelState.BusinessListingBoard state, IBusinessRepository businessRepo) : base(state)
        {
            this.businessRepo = businessRepo;
        }

        public async Task<IEnumerable<Business>> SearchForBusinesses(BusinessSearchCriteria searchCriteria)
        {
            return await this.businessRepo.Search(searchCriteria);
        }
    }

    public class BusinessSearchCriteria
    {
    }
}
