namespace Gamifyit.Politics.ModelState
{
    using System.Collections.Generic;

    public class StateAgency
    {
        public IList<StateAgent> Agents { get; set; } = new List<StateAgent>();
    }
}
