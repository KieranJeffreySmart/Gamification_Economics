namespace Gamifyit.Economics.ModelState
{
    using Gamifyit.Framework.DomainObjects;

    public class Deal : EntityState
    {
        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public Deal CloneAsSelf()
        {
            var clone = (Deal)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();
            return clone;
        }
    }
}
