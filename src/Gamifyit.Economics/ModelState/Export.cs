namespace Gamifyit.Economics.ModelState
{
    using Gamifyit.Framework.DomainObjects;

    public class Export : EntityState
    {
        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public Export CloneAsSelf()
        {
            var clone = (Export)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();
            return clone;
        }
    }
}
