namespace Gamifyit.Politics.ModelState
{
    using System.Linq;

    public class FederalState : State
    {
        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public new FederalState CloneAsSelf()
        {
            var clone = (FederalState)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();

            clone.Regulations = this.Regulations.Select(o => o.CloneAsSelf()).ToList();

            clone.StateOffces = this.StateOffces.Select(o => o.CloneAsSelf()).ToList();

            clone.StateAgencies = this.StateAgencies.Select(o => o.CloneAsSelf()).ToList();
            return clone;
        }
    }
}
