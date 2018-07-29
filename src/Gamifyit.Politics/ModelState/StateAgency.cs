namespace Gamifyit.Politics.ModelState
{
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;

    public class StateAgency : EntityState
    {
        public IList<StateAgent> Agents { get; set; } = new List<StateAgent>();
    }
}
