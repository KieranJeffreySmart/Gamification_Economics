namespace Gamifyit.Politics.ModelState
{
    using Gamifyit.Framework.DomainObjects;

    public class Regulation : EntityState
    {
        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public Regulation CloneAsSelf()
        {
            var clone = (Regulation)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();
            return clone;
        }
    }
}
