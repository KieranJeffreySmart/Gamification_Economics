namespace Gamifyit.Politics.ModelState
{
    using System.Collections.Generic;
    using System.Linq;

    public class SovreignState: State
    {
        public IList<FederalState> FederalStates { get; set; } = new List<FederalState>();
        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public new SovreignState CloneAsSelf()
        {
            var clone = (SovreignState)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();

            clone.Regulations = this.Regulations.Select(o => o.CloneAsSelf()).ToList();

            clone.StateOffces = this.StateOffces.Select(o => o.CloneAsSelf()).ToList();

            clone.StateAgencies = this.StateAgencies.Select(o => o.CloneAsSelf()).ToList();
            return clone;
        }
    }
}
