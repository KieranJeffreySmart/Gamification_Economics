using System.Collections.Generic;

namespace SpaceTrader.ModelState
{
    public class StateAgency
    {
        public IList<StateAgent> Agents { get; set; } = new List<StateAgent>();
    }
}
