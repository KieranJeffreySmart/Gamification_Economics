namespace Gamifyit.Politics.Model
{
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;

    public class FederalState : Entity<ModelState.FederalState>, IState
    {
        State baseState = new State(new ModelState.State());

        public IReadOnlyCollection<Regulation> Regulations => this.baseState.Regulations;

        public IReadOnlyCollection<StateOffice> StateOffces => this.baseState.StateOffces;

        public IReadOnlyCollection<StateAgency> StateAgencies => this.baseState.StateAgencies;

        public FederalState(ModelState.FederalState state) : base(state)
        {
        }
    }
}
