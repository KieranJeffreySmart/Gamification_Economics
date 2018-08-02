namespace Gamifyit.Politics.ModelState
{
    using System.Collections.Generic;
    using System.Linq;

    using Gamifyit.Framework.DomainObjects;

    public class State : EntityState
    {
        public IList<Regulation> Regulations { get; set; } = new List<Regulation>();
        public IList<StateOffice> StateOffces { get; set; } = new List<StateOffice>();
        public IList<StateAgency> StateAgencies { get; set; } = new List<StateAgency>();

        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public virtual State CloneAsSelf()
        {
            var clone = (State)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();

            clone.Regulations = this.Regulations.Select(o => o.CloneAsSelf()).ToList();

            clone.StateOffces = this.StateOffces.Select(o => o.CloneAsSelf()).ToList();

            clone.StateAgencies = this.StateAgencies.Select(o => o.CloneAsSelf()).ToList();
            return clone;
        }
    }
}
