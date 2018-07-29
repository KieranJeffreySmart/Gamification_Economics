namespace Gamifyit.Politics.ModelState
{
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;

    public class State : EntityState
    {
        public IList<Regulation> Regulations { get; set; } = new List<Regulation>();
        public IList<StateOffice> StateOffces { get; set; } = new List<StateOffice>();
        public IList<StateAgency> StateAgencies { get; set; } = new List<StateAgency>();
    }
}
