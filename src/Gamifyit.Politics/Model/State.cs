namespace Gamifyit.Politics.Model
{
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;

    public class State : Entity<ModelState.State>, IState
    {
        private readonly EntityCollection<Regulation, ModelState.Regulation> regulations;
        private readonly EntityCollection<StateOffice, ModelState.StateOffice> stateOffces;
        private readonly EntityCollection<StateAgency, ModelState.StateAgency> stateAgencies;

        public State(ModelState.State state) : base(state)
        {
            this.regulations = new EntityCollection<Regulation, ModelState.Regulation>(this.State.Regulations, (s) => new Regulation(s));
            this.stateOffces = new EntityCollection<StateOffice, ModelState.StateOffice>(this.State.StateOffces, (s) => new StateOffice(s));
            this.stateAgencies = new EntityCollection<StateAgency, ModelState.StateAgency>(this.State.StateAgencies, (s) => new StateAgency(s));
        }

        public IReadOnlyCollection<Regulation> Regulations => this.regulations;
        public IReadOnlyCollection<StateOffice> StateOffces => this.stateOffces;
        public IReadOnlyCollection<StateAgency> StateAgencies => this.stateAgencies;
    }
}
