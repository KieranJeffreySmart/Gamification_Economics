namespace Gamifyit.Economics.ModelState
{
    using Gamifyit.Framework.DomainObjects;

    public class Facility : EntityState
    {
        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public Facility CloneAsSelf()
        {
            var clone = (Facility)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();
            return clone;
        }
    }
}
