namespace Gamifyit.Politics.ModelState
{
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;

    public class UnionOfStates : EntityState
    {
        public IList<State> States { get; set; } = new List<State>();
    }
}
