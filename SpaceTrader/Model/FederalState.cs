using SpaceTrader.Framework.DomainObjects;
using System.Collections.Generic;

namespace SpaceTrader.Model
{
    public class FederalState : Entity<ModelState.FederalState>, IState
    {
        State baseState = new State(new ModelState.State());

        public IReadOnlyCollection<Regulation> Regulations => baseState.Regulations;

        public IReadOnlyCollection<StateOffice> StateOffces => baseState.StateOffces;

        public IReadOnlyCollection<StateAgency> StateAgencies => baseState.StateAgencies;

        public FederalState(ModelState.FederalState state) : base(state)
        {
        }
    }
}
