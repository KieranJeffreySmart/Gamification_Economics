using SpaceTrader.Framework;
using SpaceTrader.Framework.DomainObjects;
using SpaceTrader.ModelState;
using System.Collections.Generic;

namespace SpaceTrader.Model
{
    public class StateAgency : Entity<ModelState.StateAgency>
    {
        private readonly EntityCollection<StateAgent, ModelState.StateAgent> agents;

        public StateAgency(ModelState.StateAgency state) : base(state)
        {
            agents = new EntityCollection<StateAgent, ModelState.StateAgent>(this.State.Agents, (s) => new StateAgent(s));
        }

        public IReadOnlyCollection<StateAgent> Agents => agents;
    }
}
