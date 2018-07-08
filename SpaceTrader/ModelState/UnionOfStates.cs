using System.Collections.Generic;

namespace SpaceTrader.ModelState
{
    public class UnionOfStates
    {
        public IList<State> States { get; set; } = new List<State>();
    }
}
