namespace Gamifyit.Economics.ModelState
{
    using Gamifyit.Framework.DomainObjects;

    public class Company : EntityState
    {
        public Business Business { get; set; }

        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public Company CloneAsSelf()
        {
            var clone = (Company)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();
            clone.Business = this.Business.CloneAsSelf();
            return clone;
        }
    }
}
