namespace Gamifyit.Politics.ModelState
{
    using System.Collections.Generic;

    public class UnionOfStates
    {
        public IList<State> States { get; set; } = new List<State>();
    }
}
