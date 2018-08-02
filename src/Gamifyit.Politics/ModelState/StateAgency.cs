namespace Gamifyit.Politics.ModelState
{
    using System.Collections.Generic;
    using System.Linq;

    using Gamifyit.Framework.DomainObjects;

    public class StateAgency : EntityState
    {
        public IList<StateAgent> Agents { get; set; } = new List<StateAgent>();

        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public StateAgency CloneAsSelf()
        {
            var clone = (StateAgency)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();
            clone.Agents = this.Agents.Select(o => o.CloneAsSelf()).ToList();
            return clone;
        }
    }
}
