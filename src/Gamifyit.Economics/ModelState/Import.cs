namespace Gamifyit.Economics.ModelState
{
    using Gamifyit.Framework.DomainObjects;

    public class Import : EntityState
    {
        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public Import CloneAsSelf()
        {
            var clone = (Import)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();
            return clone;
        }
    }
}
