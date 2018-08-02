namespace Gamifyit.Politics.ModelState
{
    using Gamifyit.Framework.DomainObjects;

    public class StateOffice : EntityState
    {
        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public StateOffice CloneAsSelf()
        {
            var clone = (StateOffice)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();
            return clone;
        }
    }
}
