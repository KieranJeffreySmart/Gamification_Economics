using SpaceTrader.Framework;
using SpaceTrader.Framework.DomainObjects;
using System.Collections.Generic;

namespace SpaceTrader.Model
{
    public class UnionOfStates : Entity<ModelState.UnionOfStates>
    {
        public UnionOfStates(ModelState.UnionOfStates state) : base(state)
        {
            states = new EntityCollection<State, ModelState.State>(this.State.States, (s) => new State(s));
        }

        private readonly EntityCollection<State, ModelState.State> states;
        public IReadOnlyCollection<State> States => states;
    }
}
