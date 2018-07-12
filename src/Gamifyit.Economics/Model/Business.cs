namespace Gamifyit.Economics.Model
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Gamifyit.Economics.Repositories;
    using Gamifyit.Framework.DomainObjects;

    public class Business : Entity<ModelState.Business>
    {
        public Business(ModelState.Business state) : base(state)
        {
            this.offices = new EntityCollection<Office, ModelState.Office>(this.State.Offices, (s) => new Office(s));
            this.facilities = new EntityCollection<Facility, ModelState.Facility>(this.State.Facilities, (s) => new Facility(s));
            this.services = new EntityCollection<Service, ModelState.Service>(this.State.Services, (s) => new Service(s));
            this.openDeals = new EntityCollection<Deal, ModelState.Deal>(this.State.OpenDeals, (s) => new Deal(s));
            this.dealsMade = new EntityCollection<Deal, ModelState.Deal>(this.State.DealsMade, (s) => new Deal(s));
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
        public IReadOnlyCollection<Office> Offices => this.offices;
        public IReadOnlyCollection<Facility> Facilities => this.facilities;
        public IReadOnlyCollection<Service> Services => this.services;
        public IReadOnlyCollection<Deal> OpenDeals => this.openDeals;
        public IReadOnlyCollection<Deal> DealsMade => this.dealsMade;
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
