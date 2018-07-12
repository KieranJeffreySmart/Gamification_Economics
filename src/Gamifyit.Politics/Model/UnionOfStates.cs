namespace Gamifyit.Politics.Model
{
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;

    public class UnionOfStates : Entity<ModelState.UnionOfStates>
    {
        public UnionOfStates(ModelState.UnionOfStates state) : base(state)
        {
            this.states = new EntityCollection<State, ModelState.State>(this.State.States, (s) => new State(s));
        }

        private readonly EntityCollection<State, ModelState.State> states;
        public IReadOnlyCollection<State> States => this.states;
    }
}
