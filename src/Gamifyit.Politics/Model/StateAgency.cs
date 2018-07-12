namespace Gamifyit.Politics.Model
{
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;

    public class StateAgency : Entity<ModelState.StateAgency>
    {
        private readonly EntityCollection<StateAgent, ModelState.StateAgent> agents;

        public StateAgency(ModelState.StateAgency state) : base(state)
        {
            this.agents = new EntityCollection<StateAgent, ModelState.StateAgent>(this.State.Agents, (s) => new StateAgent(s));
        }

        public IReadOnlyCollection<StateAgent> Agents => this.agents;
    }
}
