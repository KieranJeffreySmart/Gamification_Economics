namespace Gamifyit.Politics.ModelState
{
    using Gamifyit.Framework.DomainObjects;

    public class StateAgent : EntityState
    {
        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public StateAgent CloneAsSelf()
        {
            var clone = (StateAgent)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();
            return clone;
        }
    }
}
