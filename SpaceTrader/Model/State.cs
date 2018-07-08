using SpaceTrader.Framework;
using SpaceTrader.Framework.DomainObjects;
using SpaceTrader.ModelState;
using System.Collections.Generic;

namespace SpaceTrader.Model
{
    public class State : Entity<ModelState.State>, IState
    {
        private readonly EntityCollection<Regulation, ModelState.Regulation> regulations;
        private readonly EntityCollection<StateOffice, ModelState.StateOffice> stateOffces;
        private readonly EntityCollection<StateAgency, ModelState.StateAgency> stateAgencies;

        public State(ModelState.State state) : base(state)
        {
            regulations = new EntityCollection<Regulation, ModelState.Regulation>(this.State.Regulations, (s) => new Regulation(s));
            stateOffces = new EntityCollection<StateOffice, ModelState.StateOffice>(this.State.StateOffces, (s) => new StateOffice(s));
            stateAgencies = new EntityCollection<StateAgency, ModelState.StateAgency>(this.State.StateAgencies, (s) => new StateAgency(s));
        }

        public IReadOnlyCollection<Regulation> Regulations => regulations;
        public IReadOnlyCollection<StateOffice> StateOffces => stateOffces;
        public IReadOnlyCollection<StateAgency> StateAgencies => stateAgencies;
    }
}
