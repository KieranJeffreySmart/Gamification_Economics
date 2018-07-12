namespace Gamifyit.Politics.ModelState
{
    using System.Collections.Generic;

    public class SovreignState: State
    {
        public IList<FederalState> FederalStates { get; set; } = new List<FederalState>();
    }
}
