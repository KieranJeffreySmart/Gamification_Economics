using SpaceTrader.Framework;
using SpaceTrader.Framework.DomainObjects;
using SpaceTrader.ModelState;
using System.Collections.Generic;

namespace SpaceTrader.Model
{
    public class SovreignState : Entity<ModelState.SovreignState>, IState
    {
        State baseState = new State(new ModelState.State());
        private readonly EntityCollection<FederalState, ModelState.FederalState> federalStates;

        public SovreignState(ModelState.SovreignState state) : base(state)
        {
            federalStates = new EntityCollection<FederalState, ModelState.FederalState>(this.State.FederalStates, (s) => new FederalState(s));
        }

        public IReadOnlyCollection<FederalState> FederalStates => federalStates;

        public IReadOnlyCollection<Regulation> Regulations => baseState.Regulations;

        public IReadOnlyCollection<StateOffice> StateOffces => baseState.StateOffces;

        public IReadOnlyCollection<StateAgency> StateAgencies => baseState.StateAgencies;
    }
}
