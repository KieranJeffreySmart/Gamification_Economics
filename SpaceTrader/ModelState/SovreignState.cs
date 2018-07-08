using System.Collections.Generic;

namespace SpaceTrader.ModelState
{
    public class SovreignState: State
    {
        public IList<FederalState> FederalStates { get; set; } = new List<FederalState>();
    }
}
