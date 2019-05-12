namespace Gamifyit.Finance.ModelState
{
    using Gamifyit.Framework.DomainObjects;

    public class Asset : EntityState
    {
        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public Asset CloneAsSelf()
        {
            var clone = (Asset)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();
            return clone;
        }
    }
}